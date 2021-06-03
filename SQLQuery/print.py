import sqlite3

#Connecting to sqlite
conn = sqlite3.connect('AppDB.db')

#Creating a cursor object using the cursor() method
cursor = conn.cursor()

#Doping EMPLOYEE table if already exists.
#cursor.execute("DROP TABLE IF EXISTS Devices")

#Creating table as per requirement
#sql = """ SELECT * FROM Measurements;"""
#sql = """ SELECT * FROM ObstaclesAmount;"""
#sql = """ SELECT * FROM Obstacles;"""
#sql = """ SELECT * FROM Devices;"""
#sql = """ SELECT * FROM Wires;"""
#sql = """ SELECT * FROM WiresAttenuation;"""
#sql = """ SELECT * FROM Connectors;"""
sql = """ SELECT * FROM Channels;"""

print(sql)
cursor.execute(sql)

rows = cursor.fetchall()

for row in rows:
    print(row)

print("Table created successfully........")

# Commit your changes in the database
conn.commit()

#Closing the connection
conn.close()