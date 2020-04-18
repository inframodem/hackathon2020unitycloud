from flask import Flask, render_template, request
#import firebase_admin
#from firebase_admin import credentials, firestore
from firebase import firebase
import configparser

app = Flask(__name__)

config = configparser.ConfigParser()
config.read('configs/config.ini')

# REALTIME DB; need to pass in firebaseio address as an argument in FirebaseApplication()
firebase = firebase.FirebaseApplication(config['firebase']['address'])   

#USING REALTIME DB NOSQL
result = firebase.get(config['firebase']['database'], '')
print(result)

@app.route("/")
def home():
    # Need to put db name inside the method to retrieve
    # result = firebase.get('dbname', '')

    return render_template('home.html') # database result passed in to display on website

if __name__ == "__main__":
    app.run(debug=True)
