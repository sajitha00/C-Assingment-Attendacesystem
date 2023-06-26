import cv2
import numpy as np
import face_recognition
import os
from datetime import datetime
import pyttsx3

# Set the absolute path to the Training_images directory
training_images_path = r'Training_images'

# Set the absolute path to the shape_predictor_68_face_landmarks.dat file
shape_predictor_path = r'shape_predictor_68_face_landmarks.dat'

# Load images from the Training_images directory
images = []
classNames = []
myList = os.listdir(training_images_path)
for cl in myList:
    curImg = cv2.imread(os.path.join(training_images_path, cl))
    images.append(curImg)
    classNames.append(os.path.splitext(cl)[0])

# Initialize a dictionary to store the last recorded times for each person
lastRecordedTimes = {}

def findEncodings(images):
    encodeList = []
    for img in images:
        img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
        encode = face_recognition.face_encodings(img)[0]
        encodeList.append(encode)
    return encodeList

def markAttendance(name):
    now = datetime.now()
    currentDate = now.strftime('%Y-%m-%d')
    currentHour = now.strftime('%H')

    # Check if the person has already been recorded in the current hour
    if name in lastRecordedTimes:
        lastRecordedHour = lastRecordedTimes[name]
        # If the person was recorded in the current hour, exit the function
        if lastRecordedHour == currentHour:
            return

    # Record the attendance and update the last recorded time for the person
    with open('Attendance.csv', 'a') as f:
        dtString = now.strftime('%H:%M:%S')
        f.writelines(f'\n{name},{currentDate},{dtString}')
        lastRecordedTimes[name] = currentHour

    # Say "Access Granted"
    engine = pyttsx3.init()
    engine.setProperty('rate', 150)
    engine.setProperty('volume', 0.8)
    engine.say('Access Granted')
    engine.runAndWait()

# Load known face encodings
encodeListKnown = findEncodings(images)
print('Encoding Complete')

cap = cv2.VideoCapture(0)

while True:
    success, img = cap.read()
    imgS = cv2.resize(img, (0, 0), None, 0.25, 0.25)
    imgS = cv2.cvtColor(imgS, cv2.COLOR_BGR2RGB)

    facesCurFrame = face_recognition.face_locations(imgS)
    encodesCurFrame = face_recognition.face_encodings(imgS, facesCurFrame)

    for encodeFace, faceLoc in zip(encodesCurFrame, facesCurFrame):
        matches = face_recognition.compare_faces(encodeListKnown, encodeFace)
        faceDis = face_recognition.face_distance(encodeListKnown, encodeFace)
        matchIndex = np.argmin(faceDis)

        if matches[matchIndex]:
            name = classNames[matchIndex].upper()
            y1, x2, y2, x1 = faceLoc
            y1, x2, y2, x1 = y1 * 4, x2 * 4, y2 * 4, x1 * 4
            cv2.rectangle(img, (x1, y1), (x2, y2), (0, 255, 0), 2)
            cv2.rectangle(img, (x1, y2 - 35), (x2, y2), (0, 255, 0), cv2.FILLED)
            cv2.putText(img, name, (x1 + 6, y2 - 6), cv2.FONT_HERSHEY_COMPLEX, 1, (255, 255, 255), 2)
            markAttendance(name)

    cv2.imshow('Webcam', img)
    if cv2.waitKey(1) == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()
