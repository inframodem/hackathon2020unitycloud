from flask import Flask, render_template, request
from firebase import firebase

app = Flask(__name__)

@app.route("/")
def home():
    return render_template('home.html') # database result passed in to display on website

if __name__ == "__main__":
    app.run(debug=True)
