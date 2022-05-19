// You can edit this code!
// Click here and start typing.
package main

import (
	"fmt"
)

func fibonacci() func() int {
	f1, f2 := 0, 1
	return func() int {
		temp := f1
		f1, f2 = f2, f1+f2
		return temp
	}
}

func main() {
	f := fibonacci()
	for i := 0; i < 10; i++ {
		fmt.Println(f())
	}

}
