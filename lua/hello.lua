#!/usr/local/bin/lua

print("hello lua")
print("lua !!!!")

--this is comment
--[[
    this 
    is 
    comment
]]--

asdf=100
print(asdf)
a=nil
print(a)

-- data type
print(type(a))
print(type(nil))
print(type(true))
tab1 = {key1="val1", key2 = "2222r", 345, "item4"}
for k, v in pairs(tab1) do
    print(k .. ' - '.. v)
end
print("type 返回的是字符串")
print('nil'==type(nil))
print('boolean'==type(true))

html = [[
<html>
<head></head>
<body>
    <a href="http://www.runoob.com/">菜鸟教程</a>
</body>
</html>
]]
print(html)

function func1(n)
    if n ==0 then
        return 1
    else
        return n*func1(n-1)
    end
end
print(func1(4))
func2 = func1
print(func2(3))