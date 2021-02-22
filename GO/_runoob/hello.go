package main

import "fmt"
import "mime/multipart"

func main() {
	fmt.Print("this is the begining", "\n")

	var test string
	test = "test string"
	test2 := "test2 string"
	fmt.Println(test, test2)

	showConst()

	testOperator()

	_, r2, r3 := addNumbers(12, 33, "the sum is: ")
	fmt.Println(r3, r2)
}

func addNumbers(a, b int, desc string) (int, int, string) {
	var result int = a + b

	return 0, result, desc
}

func showConst() {
	const a, b = "test", true
	// a = "modify"
	fmt.Print(a, b)
	fmt.Println("")
}

func testOperator() {
	const a, b, c = 1, 2.5, 3
	var b1 bool
	b2, s1 := true, "string"

	fmt.Println(a+b+c, ", ", b1, ", ", b2)
	fmt.Println(string(a)+s1, string(a))
}
