package main

import "fmt"

var container = []string{"zero","one","two"}

func main() {

	m, ok1 := interface{}(container).([]string)
	fmt.Println(m)
	fmt.Println(ok1)

	container := map[int]string{0:"zero",1:"one",2:"two"}
	m2, ok2 := interface{}(container).(map[int]string)
	fmt.Println(m2)
	fmt.Println(ok2)

	fmt.Printf("the element is %q.\n", container[1])
}