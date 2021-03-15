-- 因此 Lua 提供了元表(Metatable)，允许我们改变table的行为，每个行为关联了对应的元方法。
-- 例如，使用元表我们可以定义Lua如何计算两个table的相加操作a+b。
-- 当Lua试图对两个表进行相加时，先检查两者之一是否有元表，之后检查是否有一个叫"__add"的字段，若找到，则调用对应的值。"__add"等即时字段，其对应的值（往往是一个函数或是table）就是"元方法"。
-- 有两个很重要的函数来处理元表：
-- setmetatable(table,metatable): 对指定 table 设置元表(metatable)，如果元表(metatable)中存在 __metatable 键值，setmetatable 会失败。
-- getmetatable(table): 返回对象的元表(metatable)。
index_tab = {
    foo = 4,
    test = 3
}
index_tab[3] = "val3"
mytab = {}
metatab = {
    __index = index_tab,
    __newindex = function(t, k, v)
        print("error to update read only table")
    end
}
setmetatable(mytab, metatab)
print(mytab.foo, mytab[3], mytab[2])
mytab[1] = "test"

function readOnly(t)
    local proxy = {} --定义一个空表，访问任何索引都是不存在的，所以会调用__index 和__newindex
    local mt = {
        __index = t, ---__index 可以是函数，也可以是table，是table的话，调用直接返回table的索引值
        __newindex = function(t, k, v)
            print("attempt to update a read-only table")
        end
    }
    setmetatable(proxy, mt)
    return proxy
end
days = readOnly {"Sunday", "Monday", "Tuesday", "Wednessday", "Thursday", "Friday", "Saturday"}
print(days[1])
days[2] = "hello"
