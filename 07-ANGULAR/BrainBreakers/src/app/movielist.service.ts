import { Injectable } from "@angular/core";
import Note from "./note.ts";
import { Observable, of } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class MovieListService {
  movielist: Note[] = [
    { id: 0, text: "A", date: new Date("2019-01-16") },
    { id: 1, text: "B", date: new Date("2010-11-10") },
    { id: 2, text: "C", date: new Date("2019-09-26") },
    { id: 3, text: "D", date: new Date("2022-06-11") },
    { id: 4, text: "E", date: new Date("2000-02-02") }
  ];

  id: number = 5;

  getList(): Observable<Note[]> {
    return of(this.movielist);
  }

  addList(note: Note): void {
    if (!note.text) {
      return;
    }
    note.id = this.id++;
    note.date = new Date();
    this.movielist.push(note);
  }

  constructor() {}
}
