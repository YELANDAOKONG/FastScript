#encoding utf8;
#using native;
#native import "System";

import fastscript.network.socket;
from fastscript.lang import *;
from fastscript.hashlib import SHA256, SHA384;
from fastscript.keyword import KeyWordList;
from fastscript.time import DateTime as Time;


func print(any... args, char end = "\n"){
    any[] str_args = new any[];
    for(any arg in args){
        try{
            string str = arg.toString();
            str_args.add(str);
        }catch(TypeControlException ex){
            str_args.add(arg.toString());
        }
    }
    for(string str in str_args){
        for(char c in str){
            Native.CallFunction("Console.Write", c);
        }
    }
    Native.CallFunction("Console.Write", end);
}

print(114514.1919810);



