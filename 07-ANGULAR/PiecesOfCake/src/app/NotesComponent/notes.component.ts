import { Component, OnInit } from "@angular/core";
import Note from "./note.ts";

@Component({
  selector: "app-notes",
  templateUrl: "./notes.component.html",
  styleUrls: ["./notes.component.css"]
})
export class NotesComponent implements OnInit {
  notes: Note[] = [
    { text: "A", date: new Date("2019-01-16") },
    { text: "B", date: new Date("2010-11-10") },
    { text: "C", date: new Date("2019-09-26") },
    { text: "D", date: new Date("2022-06-11") },
    { text: "E", date: new Date("2000-02-02") }
  ];

  constructor() {}

  ngOnInit(): void {}
}
