-- Lua 变量有三种类型：全局变量、局部变量、表中的域。
function joke()
    c = 5
    local d = 6
end

joke()
print(c, d)

a = 5
local b = 6

do
    local a = 6
    b = 7
    print(a, b)
end
print(a, b)

-- continue
for i = 1, 5 do
    if i <= 2 then
        print(i, "goto continue")
        goto continue
    end
    print(i, "no continue")
    ::continue::
    print(i, "end")
end

-- 获取表的长度
tab3 = {}
tab3[1] = 1
tab3[2] = 2
print("tab3 长度" .. #tab3)
tab3 = {}
tab3[1] = 1
tab3[2] = 2
tab3[5] = 2
tab3[4] = 2
print("tab3 长度" .. #tab3)
tab3 = {}
tab3[1] = 1
tab3[2] = 2
tab3[5] = 2
tab3[4] = nil
print("tab3 长度" .. #tab3)

--数组 迭代器
-- pairs: 迭代 table，可以遍历表中所有的 key 可以返回 nil
--  ipairs: 迭代数组，不能返回 nil,如果遇到 nil 则退出
array = {"google", "baidu"}
for k, v in ipairs(array) do
    print(k .. v)
end
function eIter(coll)
    local index = 0
    local count = #coll
    return function()
        index = index + 1
        if index <= count then
            return coll[index]
        end
    end
end

for e in eIter(array) do
    print(e)
end

-- table
-- table = {}
-- table[1] = "test"
fruits = {"banana"}
fruits[2] = "orange"
fruits[1] = "before orange"
fruits[5] = "end orange"
-- 返回 table 连接后的字符串

print("连接后的字符串 ", table.concat(fruits))
for key, value in pairs(fruits) do
    print(key .. value)
end
