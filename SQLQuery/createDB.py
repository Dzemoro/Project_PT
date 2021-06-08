import sqlite3

def ReadQuery(path):
    with open(path, 'r') as file:
        content = file.read()
    return content

#Connecting to sqlite
conn = sqlite3.connect('AppDB.db')

#Creating a cursor object using the cursor() method
cursor = conn.cursor()
cursor.execute('PRAGMA encoding="UTF-8";')
#Doping EMPLOYEE table if already exists.
#cursor.execute("DROP TABLE IF EXISTS Devices")

#Creating table as per requirement
sql = ReadQuery('fixes.sql')
cursor.executescript(sql)
print("Table created successfully........")

# Commit your changes in the database
conn.commit()

#Closing the connection
conn.close()