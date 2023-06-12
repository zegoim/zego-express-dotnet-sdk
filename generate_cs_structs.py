import sys
import re
from enum import Enum

# param types
class ParamType(Enum):
    PARAM_TYPE_STRING = 0,  # char[64]
    PARAM_TYPE_UINT_64 = 1, # unsigned long long
    PARAM_TYPE_UINT_32 = 1, # unsigned int
    PARAM_TYPE_ENUM = 2,    # enum
    PARAM_TYPE_BOOL = 3,    # bool
    PARAM_TYPE_INT = 4,     # int
    PARAM_TYPE_FLOAT = 5,   # float
    PARAM_TYPE_ARRAY_INT = 6,   # int a[3]
    PARAM_TYPE_ARRAY_FLOAT = 7,   # float a[3]
    PARAM_TYPE_STRUCT = 8,  # struct xxx p
    PARAM_TYPE_POINTER = 9, # void *p
    PARAM_TYPE_DOUBLE = 10 # double
    PARAM_TYPE_INT64 = 11 # long long

# param type internal, pointer/array/value
class ParamTypeInternal(Enum):
    POINTER = 0,    # pointer tpye
    ARRAY   = 1,    # array type
    VALUE   = 2     # value type

# param name, param type, param length, type name
# Convert name to camel case
def name_convert_to_camel(name: str) -> str:
    return re.sub(r'(_[a-z])', lambda a:a.group(1)[1].upper(), name)

# Convert native type name to cs type name
def native_type_name_to_cs(name: str, type: ParamTypeInternal):
    # pointer
    if type == ParamTypeInternal.POINTER:
        return ('public System.IntPtr', ParamType.PARAM_TYPE_POINTER)
    # array
    elif type == ParamTypeInternal.ARRAY:
        # if char aray
        pattern_char = '^char$'
        result = re.search(pattern_char, name)
        if result:
            return ('public byte[]', ParamType.PARAM_TYPE_STRING)
        # if int array
        pattern_int = '^int$'
        result = re.search(pattern_int, name)
        if result:
            return ('public int[]', ParamType.PARAM_TYPE_ARRAY_INT)
        # if float array
        pattern_float = '^float$'
        result = re.search(pattern_float, name)
        if result:
            return ('public float[]', ParamType.PARAM_TYPE_ARRAY_FLOAT)
    elif type == ParamTypeInternal.VALUE:
        #if long long
        pattern_long_long = '^(long)( {1,})(long)$'
        result = re.search(pattern_long_long, name)
        if result:
            return ('public long', ParamType.PARAM_TYPE_INT64)
        # if unsigned long long
        pattern_ulong = '^(unsigned)( {1,})(long)( {1,})(long)$'
        result = re.search(pattern_ulong, name)
        if result:
            return ('public ulong', ParamType.PARAM_TYPE_UINT_64)
        # if unsigned int
        pattern_uint = '^(unsigned)( {1,})(int)$'
        result = re.search(pattern_uint, name)
        if result:
            return ('public uint', ParamType.PARAM_TYPE_UINT_32)
        # if enum
        pattern_enum = '^(enum)( {1,})([a-zA-Z_0-9]{1,})$'
        result = re.search(pattern_enum, name)
        if result:
            return ('public ' + result.groups()[2], ParamType.PARAM_TYPE_ENUM)
        # if bool
        pattern_bool = '^bool$'
        result = re.search(pattern_bool, name)
        if result:
            return ('public bool', ParamType.PARAM_TYPE_BOOL)
        # if int 
        pattern_int = '^int$'
        result = re.search(pattern_int, name)
        if result:
            return ('public int', ParamType.PARAM_TYPE_INT)
        # if float
        pattern_float = '^float$'
        result = re.search(pattern_float, name)
        if result:
            return ('public float', ParamType.PARAM_TYPE_FLOAT)
        # if double
        pattern_double = '^double$'
        result = re.search(pattern_double, name)
        if result:
            return ('public double', ParamType.PARAM_TYPE_DOUBLE)
        # if struct
        pattern_struct = '^(struct)( {1,})([a-zA-Z_0-9]{1,})$'
        result = re.search(pattern_struct, name)
        if result:
            return ('public '+result.groups()[2], ParamType.PARAM_TYPE_STRUCT)
        # if struct
        pattern_struct = '^([a-zA-Z_0-9]{1,})$'
        result = re.search(pattern_struct, name)
        if result:
            return ('public '+result.groups()[0], ParamType.PARAM_TYPE_STRUCT)

line_spaces_of_tab = '    '

# express native c header file
file_path_zego_express_defines_h = '../../src/include/zego-express-defines.h'

# cs struct file
file_path_zego_struct_cs = 'ZegoExpressCsharp/ZegoStruct.cs'
dest_file_path_zego_struct_cs = 'ZegoExpressCsharp/ZegoStruct.cs'

# native c structs dic
native_structs_dic = {}

# cs structs dic
cs_structs_dic = {}

cs_new_line = '\n'

if __name__ == '__main__':
    # Read files
    is_struct_start = False
    is_struct_end = False

    is_enum_start = False
    is_enum_end = False
    is_enum_name_line = False
    
    struct_dict = {}
    struct_name = ''
    struct_content = []
    cs_struct_file_lines = []

    cs_struct_file_lines.append('using System;'+ cs_new_line)
    cs_struct_file_lines.append('using System.Collections;'+ cs_new_line)
    cs_struct_file_lines.append('using System.Collections.Generic;'+ cs_new_line)
    cs_struct_file_lines.append('using System.Runtime.InteropServices;'+ cs_new_line)
    cs_struct_file_lines.append('namespace ZEGO'+ cs_new_line)
    cs_struct_file_lines.append('{'+ cs_new_line)

    #native_type_name_to_cs('stream_alignment_mode', 2)

    # native file structs
    with open(file_path_zego_express_defines_h, 'rt', encoding='utf-8') as f:
        while True:
            line = f.readline()
            if not line:
                break
            line = line.strip()
            if line.__len__() is 0:
                cs_struct_file_lines.append(cs_new_line)
                continue
            if line.__contains__('///'):
                if is_struct_start is True or is_enum_start is True:
                    cs_struct_file_lines.append(line_spaces_of_tab*2 + line + cs_new_line)
                else:
                    cs_struct_file_lines.append(line_spaces_of_tab + line + cs_new_line)
                continue
            if is_struct_start is False:
                re_pattern_struct_name = r'(struct )([0-9a-zA-Z_]{1,})( {0,}\{)'
                result = re.search(re_pattern_struct_name, line)
                if result:
                    is_struct_start = True
                    struct_name = result.groups()[1]
                    cs_struct_file_lines.append(line_spaces_of_tab + 'public ' + line + cs_new_line)
                    print("struct begin, name:{}".format(struct_name))
            if is_enum_start is False:
                re_pattern_enum_name = r'(enum )([0-9a-zA-Z_]{1,})( {0,}\{)'
                result = re.search(re_pattern_enum_name, line)
                if result:
                    is_enum_start = True
                    is_enum_name_line = True
                    enum_name = result.groups()[1]
                    cs_struct_file_lines.append(line_spaces_of_tab + 'public ' + line + cs_new_line)
                    print("enum begin, name:{}".format(enum_name))

            if is_enum_start is True:
                # copy each line
                if line.__contains__("}"):
                    if is_enum_start:
                        is_enum_end = True
                        print("enum end")
                if is_enum_end is True:
                    is_enum_start = False
                    is_enum_end = False
                    is_enum_name_line = False
                    cs_struct_file_lines.append(line_spaces_of_tab + "}" + cs_new_line)
                else:
                    if not is_enum_name_line:
                        cs_struct_file_lines.append(line_spaces_of_tab*2 + line + cs_new_line)
                    is_enum_name_line = False

            if is_struct_start is True:
                #struct_content += line
                
                # 值类型 空格+字母数字下划线+分号
                re_pattern_str_1 = r'( )([0-9a-zA-Z_]{1,})(;)'
                # 指针类型 空格+*+字母数字下划线+分号
                re_pattern_str_2 = r'( )(\*{1,})([0-9a-zA-Z_]{1,})(;)'
                # 数组类型 空格+字母数字下划线+[字母数字下划线]+分号
                re_pattern_str_3 = r'( )([0-9a-zA-Z_]{1,})(\[)([0-9a-zA-Z_]{1,})(\])(;)'

                regex_1 = re.compile(re_pattern_str_1)
                regex_2 = re.compile(re_pattern_str_2)
                regex_3 = re.compile(re_pattern_str_3)

                resultx1 = re.search(regex_1, line)#regex_1.search(line)
                resultx2 = regex_2.search(line)
                resultx3 = regex_3.search(line)
                param_name = None
                param_type_name_str = None
                param_size = None
                param_cs_property_str = None
                if resultx1:
                    param_name = resultx1.groups()[1]
                    test_str = '123123123123123'
                    end_index : int = (-len(param_name) - 1)
                    param_type_str = line[0:end_index].strip()
                    param_type_cs = native_type_name_to_cs(param_type_str, ParamTypeInternal.VALUE)

                    if param_type_cs:
                        param_line_str = param_type_cs[0] + ' ' + param_name + ';'
                        # bool
                        if param_type_cs[1] is ParamType.PARAM_TYPE_BOOL:
                            property_line_str = '[MarshalAs(UnmanagedType.I1)]'
                            cs_struct_file_lines.append(line_spaces_of_tab*2 + property_line_str + cs_new_line)
                        cs_struct_file_lines.append(line_spaces_of_tab*2 + param_line_str + cs_new_line)
                    else:
                        print('Not support param type, line string: {}'.format(line))
                        break
                elif resultx2:
                    param_name = resultx2.groups()[2]
                    param_line_str = 'public System.IntPtr ' + param_name + ';'
                    cs_struct_file_lines.append(line_spaces_of_tab*2 + param_line_str + cs_new_line)
                elif resultx3:
                    param_name = resultx3.groups()[1]
                    end_index : int = (-len(resultx3.groups()[1] + resultx3.groups()[2] + resultx3.groups()[3] + resultx3.groups()[4] + resultx3.groups()[5]) - 1)
                    param_type_str = line[0:end_index].strip()
                    param_type_cs = native_type_name_to_cs(param_type_str, ParamTypeInternal.ARRAY)
                    param_line_str = param_type_cs[0] + ' ' + param_name + ';'

                    if param_type_cs:
                        property_line_str = None
                        size_str = resultx3.groups()[3]
                        if not size_str.isdigit():
                            size_str = 'ZegoConstans.' + size_str
                        # string
                        if param_type_cs[1] is ParamType.PARAM_TYPE_STRING:
                            property_line_str = '[MarshalAs(UnmanagedType.ByValArray, SizeConst = ' + size_str + ')]'
                        # int[]
                        elif param_type_cs[1] is ParamType.PARAM_TYPE_ARRAY_INT:
                            property_line_str = '[MarshalAs(UnmanagedType.ByValArray, SizeConst = ' + size_str + ', ArraySubType = UnmanagedType.I4)]'
                        # float[]
                        elif param_type_cs[1] is ParamType.PARAM_TYPE_ARRAY_FLOAT:
                            property_line_str = '[MarshalAs(UnmanagedType.ByValArray, SizeConst = ' + size_str + ', ArraySubType = UnmanagedType.R4)]'
                        if property_line_str:
                            cs_struct_file_lines.append(line_spaces_of_tab*2 + property_line_str + cs_new_line)
                        cs_struct_file_lines.append(line_spaces_of_tab*2 + param_line_str + cs_new_line)
                    else:
                        print('Not support param type, line string: {}'.format(line))
                        break
                
                if param_name != None:
                    struct_content.append(param_name)
                
                
                if line.__contains__("}"):
                    is_struct_end = True
                    cs_struct_file_lines.append(line_spaces_of_tab + line + cs_new_line)
                    print("struct end")

                if is_struct_end is True:
                    print(struct_content)
                    if len(struct_content) > 0:
                        struct_dict = {struct_name:struct_content}
                        native_structs_dic.update(struct_dict)

                    struct_content = []
                    is_struct_start = False
                    is_struct_end = False

    cs_struct_file_lines.append('}' + cs_new_line)
    # write cs struct file
    with open(dest_file_path_zego_struct_cs, 'w', encoding='utf-8') as f:
        f.writelines(cs_struct_file_lines)
    is_struct_start = False
    is_struct_end = False
    
    struct_dict = {}
    struct_name = ''
    struct_content = []

    # cs file structs
    with open(file_path_zego_struct_cs, 'rt', encoding='utf-8') as f:
        while True:
            line = f.readline()
            if not line:
                break
            if line.__contains__('///'):
                continue
            if line.__contains__('/**'):
                continue
            if is_struct_start is False:
                re_pattern_struct_name = r'(public struct )([0-9a-zA-Z_]{1,})'
                result = re.search(re_pattern_struct_name, line)
                if result:
                    is_struct_start = True
                    struct_name = result.groups()[1]
                    print("cs struct begin, name:{}".format(struct_name))

            if is_struct_start is True:
                #struct_content += line
                
                # 空格+字母数字下划线+分号
                re_pattern_str_1 = r'( )([0-9a-zA-Z_]{1,})(;)'
                regex_1 = re.compile(re_pattern_str_1)
                resultx1 = re.search(regex_1, line)

                param_name = None
                if resultx1:
                    param_name = resultx1.groups()[1]
                elif resultx2:
                    param_name = resultx2.groups()[2]
                elif resultx3:
                    param_name = resultx3.groups()[1]
                
                if param_name != None:
                    struct_content.append(param_name)
                
                
                if line.__contains__("}"):
                    is_struct_end = True
                    print("cs struct end")

                if is_struct_end is True:
                    print(struct_content)
                    if len(struct_content) > 0:
                        struct_dict = {struct_name:struct_content}
                        cs_structs_dic.update(struct_dict)

                    struct_content = []
                    is_struct_start = False
                    is_struct_end = False
    # check if cs structs' param is complete
    for cs_struct_name in cs_structs_dic:
        if native_structs_dic.__contains__(cs_struct_name):
            # all cs params

            cs_params = cs_structs_dic[cs_struct_name]
            native_params = native_structs_dic[cs_struct_name]

            for param in cs_params:
                if param not in native_params:
                    print("cs struct name:{0}, param not include:{1}".format(cs_struct_name, param))

    
