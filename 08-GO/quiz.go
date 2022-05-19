// You can edit this code!
// Click here and start typing.
package main

import (
	"encoding/csv"
	"fmt"
	"log"
	"os"
	"strconv"
)

type Question struct {
	question string
	answer   string
}

func convertData(data [][]string) []Question {
	var questionList []Question
	for _, line := range data {
		var q Question
		for j, field := range line {
			if j == 0 {
				q.question = field
			} else if j == 1 {
				q.answer = field
			}
		}
		questionList = append(questionList, q)
	}
	return questionList
}

func main() {
	f, err := os.Open("quiz.csv")
	if err != nil {
		fmt.Println(err)
	}
	defer f.Close()

	csvReader := csv.NewReader(f)
	data, err := csvReader.ReadAll()
	if err != nil {
		log.Fatal(err)
	}

	questions := convertData(data)

	var answer string
	correct := 0
	incorrect := 0

	for i, q := range questions {
		fmt.Printf("\x1bc")
		fmt.Println("Quiz")
		fmt.Println("correct: " + strconv.Itoa(correct) + ", incorrect: " + strconv.Itoa(incorrect))
		fmt.Println(strconv.Itoa(i) + ".Answer the question: " + q.question)
		fmt.Scanln(&answer)
		if answer == q.answer {
			correct++
		} else {
			incorrect++
		}
	}
	fmt.Println("Your score is " + strconv.Itoa(correct) + " out of " + strconv.Itoa(correct+incorrect) + ".")
}
