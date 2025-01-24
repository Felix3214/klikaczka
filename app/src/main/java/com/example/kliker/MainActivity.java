package com.example.kliker;

import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private TextView counterTextView;
    private Button incrementButton, resetButton, toggleButton, confirmButton;
    private EditText stepEditText;
    private int counter = 0;
    private boolean isIncrementing = true;
    private int step = 1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        counterTextView = findViewById(R.id.counterTextView);
        incrementButton = findViewById(R.id.incrementButton);
        resetButton = findViewById(R.id.resetButton);
        toggleButton = findViewById(R.id.toggleButton);
        confirmButton = findViewById(R.id.confirmButton);
        stepEditText = findViewById(R.id.stepEditText);

        incrementButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (isIncrementing) {
                    counter += step;
                } else {
                    counter -= step;
                }
                updateCounter();
            }
        });

        resetButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                counter = 0;
                updateCounter();
            }
        });


        toggleButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                isIncrementing = !isIncrementing;
                if (isIncrementing) {
                    toggleButton.setText("odejmij!");
                } else {
                    toggleButton.setText("dodaj!");
                }
            }
        });

        confirmButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String stepValue = stepEditText.getText().toString();
                if (!TextUtils.isEmpty(stepValue)) {
                    try {
                        step = Integer.parseInt(stepValue);
                        Toast.makeText(MainActivity.this, "Skok ustawiony na: " + step, Toast.LENGTH_SHORT).show();
                    } catch (NumberFormatException e) {
                        Toast.makeText(MainActivity.this, "Niepoprawny numer skoku", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    Toast.makeText(MainActivity.this, "podaj skoook!!!", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    private void updateCounter() {
        counterTextView.setText(String.valueOf(counter));
    }
}
