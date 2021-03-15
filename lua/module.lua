module = {}
module.constant = "this is a coonstant value"
function module.func1()
    io.write("this is function1 from module")
end
function module.func2()
    io.write("this is function2 from module")
end
return module
