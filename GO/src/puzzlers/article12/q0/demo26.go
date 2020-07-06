package main

import "fmt"

type Printer func(contents string) (n int, err error)

func printToStd(s string) (bytesNum int, err error) {
	return fmt.Println(s)
}

func main() {
	var p Printer
	p = printToStd
	p("something")
}
