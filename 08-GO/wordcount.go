// You can edit this code!
// Click here and start typing.
package main

import (
	"fmt"
	"strings"
)

func main() {
	text := "Create a program that will read in a quiz provided via a CSV file (more details below) and will then give the quiz to a user keeping track of how many questions they get right and how many they get incorrect. Regardless of whether the answer is correct or wrong the next question should be asked immediately afterwards"
	words_freq := make(map[string]int)
	words := strings.Fields(text)
	for _, word := range words {
		words_freq[word]++
	}
	fmt.Println(words_freq)
}
