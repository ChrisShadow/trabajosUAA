from ensurepip import version
from itertools import count
import psycopg2
from psycopg2 import connect
from psycopg2 import Error

try:
    connection= psycopg2.connect(user='postgres',
    password='123ABC459',
    host='127.0.0.1',
    port="5432",
    database='uaa2022') 
    cursor=connection.cursor()

    #Postg version
    cursor.execute('select version();')
    version=cursor.fetchone()
    print("Conectado a -", version, "\n")
    
    ''' #Insert
    insert_query="""insert into cliente (Nombre, Apellido) values ('Pedro','Del Mar')"""
    cursor.execute(insert_query)
    connection.commit()
    print("Registro insertado correctamente\n") '''

    ''' #Update 
    update_query="""update cliente set nombre='Javer', apellido='Mendoza' where cod=2 """
    cursor.execute(update_query)
    connection.commit()
    count=cursor.rowcount
    print(count,"Registro actualizado correctamente\n") '''

    ''' #Delete
    delete_query="""delete from cliente  where cod=3 """
    cursor.execute(delete_query)
    connection.commit()
    count=cursor.rowcount
    print(count,"Registro eliminado correctamente\n") '''

   #Select
    select_query='select * from cliente'
    cursor.execute(select_query)
    registros=cursor.fetchall()
    for r in registros:
        cod=r[0]
        nombre=r[1]
        apellido=r[2]
        print("Hola",nombre,apellido,", tu registro es el número",cod)

        
except (Exception, Error) as error:
    print("Error mientras se intentó conectar a PostgreSQL:", error)
finally:
    if(connection):
        cursor.close()
        connection.close()
        print("\nLa conexión de PostgreSQL está cerrada")
