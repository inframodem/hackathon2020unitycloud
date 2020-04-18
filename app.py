from flask import Flask, render_template, request
#import firebase_admin
#from firebase_admin import credentials, firestore
from firebase import firebase

app = Flask(__name__)

# REALTIME DB; need to pass in firebaseio address as an argument in FirebaseApplication()
# firebase = firebase.FirebaseApplication()   

""" USING REALTIME DB NOSQL
data = {
    'Name': 'Hello There',
    'Score': 5
}

result = firebase.post('', data)    # Need to pass in db in first argument
print(result)
"""

""" USING FIRESTORE NOSQL
cred = credentials.Certificate()    # Pass in service account json key obtained from GCP
firebase_admin.initialize_app(cred)
db = firestore.client()

doc_ref = db.collection(u'users').document(u'test')
doc_ref.set({
    u'name': u'test name',
    u'score': 0
})

users_ref = db.collection(u'users')
docs = users_ref.stream()

for doc in docs:
    print(u'{} => {}'.format(doc.id, doc.to_dict()))
"""


@app.route("/")
def home():
    # Need to put db name inside the method to retrieve
    # result = firebase.get('dbname', '')

    return render_template('home.html') # database result passed in to display on website

if __name__ == "__main__":
    app.run(debug=True)
