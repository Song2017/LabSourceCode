require('module')

print(module.constant)
module.func1()


-- local path = "/usr/local/lua/lib/libluasocket.so"
-- -- 或者 path = "C:\\windows\\luasocket.dll"，这是 Window 平台下
-- local f = assert(loadlib(path, "luaopen_socket"))
-- f()  -- 真正打开库