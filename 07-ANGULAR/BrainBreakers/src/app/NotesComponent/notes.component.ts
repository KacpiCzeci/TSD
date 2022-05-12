import { Component, OnInit } from "@angular/core";
import Note from "../note.ts";
import { MovieListService } from "../movielist.service";

@Component({
  selector: "app-notes",
  templateUrl: "./notes.component.html",
  styleUrls: ["./notes.component.css"]
})
export class NotesComponent implements OnInit {
  notes: Note[] = [];

  constructor(private movieListService: MovieListService) {}

  ngOnInit(): void {
    this.getNotes();
  }

  getNotes(): void {
    this.movieListService.getList().subscribe((notes) => (this.notes = notes));
  }

  addNote(note: Note): void {
    this.movieListService.addList(note);
  }
}
