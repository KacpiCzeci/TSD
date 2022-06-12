package com.example.myapplication

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.TextView
import androidx.transition.Visibility

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        var button = findViewById<Button>(R.id.button)
        var text = findViewById<TextView>(R.id.textView)

        button.setOnClickListener {
            if(text.visibility.equals(View.VISIBLE)){
                text.visibility = View.INVISIBLE
            }
            else {
                text.visibility = View.VISIBLE
            }
        }
    }
}