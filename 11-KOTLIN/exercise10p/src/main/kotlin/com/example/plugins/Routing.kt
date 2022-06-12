package com.example.plugins

import io.ktor.server.routing.*
import io.ktor.http.*
import io.ktor.server.application.*
import io.ktor.server.response.*
import io.ktor.server.request.*
import com.example.Response

fun Application.configureRouting() {

    routing {
        get("/{text?}{times?}") {
            var text = call.parameters["text"]
            var times = call.parameters["times"]
            if (text !== null && times !== null) {
                var resp = ""
                for (i in 1..times.toInt()) {
                    //print(text + "\n")
                    resp = resp + text + "\n"
                }
                call.respondText(resp)
            }
            else{
                call.respondText("Wrong input")
            }

        }
    }
}
