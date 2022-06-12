package com.example.exercise15p

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.lifecycle.lifecycleScope
import kotlinx.coroutines.launch
import io.ktor.client.*
import io.ktor.client.call.*
import io.ktor.client.engine.cio.*
import io.ktor.client.request.*

class MainActivity() : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val button = findViewById<Button>(R.id.button2)
        var text = findViewById<TextView>(R.id.editTextTextPersonName)
        var times = findViewById<TextView>(R.id.editTextNumber)
        var body = findViewById<TextView>(R.id.textView)

        button.setOnClickListener() {
            lifecycleScope.launch {
                val client = HttpClient(CIO)
                val response = client.get("https://KacperMacBook/?${text.text}&${times.text}")
                body.text = response.body()
                client.close()
            }
        }
    }
}