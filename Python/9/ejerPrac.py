from ensurepip import version
from itertools import count
import psycopg2
from psycopg2 import connect
from psycopg2 import Error

def consultar(select_query):
    cursor.execute(select_query)
    registros=cursor.fetchall()
    return registros

def consultarParms(select_query,par):
    cursor.execute(select_query,par)
    registros=cursor.fetchall()
    return registros

def grabar(query,par):
    cursor.execute(query,par)
    connection.commit()

def desplegar():
    select_query='select * from cliente order by apellido,cliente' 
    registros=consultar(select_query)
    print("Datos del cliente\n")
    for r in registros:
        cod=r[0]
        nombre=r[1]
        apellido=r[2]
        print(cod,",",nombre," ",apellido)
    return

def busqueda(cod):
    select_query='select * from cliente where cod=%s'
    par=(cod,)
    cliente=consultarParms(select_query,cod)
    return cliente

def buscardesplegarDatos():
    cod=input("Ingrese el código del cliente(ID)\n")
    cliente=busqueda(cod)
    if cliente:
        cod=cliente[0][0]//tupla: titulo:valor tupla
        nombre=cliente[0][1]
        apellido=cliente[0][2]
        print("Datos del cliente\n")
        print("Cód:",cod,"\nNombre:",nombre,"\nApellido:",apellido,"\n")
    else:
        print("No existe un cliente con cód:",cod)
    return cliente

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

    dicOpc={1:'Agregar',2:'Modificar',3:'Borrar',99:'Fin'}
    desplegar()
    while True:
        print("\n--MENÚ DE OPERACIONES--")
        for k,v in dicOpc.items():
            print("  ",k,v)
        dato=input("\nIngrese una opción a ejecutar:")
        try:
            opcion=int(dato)
            if opcion==1:
              desplegar()
              print("\nAgregando registros\n")
              nom=input("Ingrese el nombre:\n")
              ape=input("Ingrese el apellido::\n")
              insert_query="""insert into cliente (nombre, apellido) values (%s,%s)"""
              par=(nom,ape)
              grabar(insert_query,par)
              print("Registro insertado correctamente\n")

            elif opcion==2:
                cliente=buscardesplegarDatos()
                if cliente:
                    print("Ingrese los nuevos datos")
                    namN=input("Ingrese el nombre:\n")
                    apeN=input("Ingrese el apellido:\n")
                    cod=cliente[0][0]
                    nombre=cliente[0][1]
                    apellido=cliente[0][2]

                    if namN:
                        if nombre!=namN:
                            nombre=namN
                    if apeN:
                        if apellido!=apeN:
                            apellido=apeN
                    insert_query="""update cliente set nombre=%s, apellido=%s where cod=%s """
                    par=(nombre,apellido,cod)
                    grabar(insert_query,par)
                    print("Registro actualizado correctamente\n")
                else:
                    print("No existe un cliente con cód:",cod)

            elif opcion==3:
                cliente=buscardesplegarDatos()
                if cliente:
                    cod=cliente[0][0]
                    delete=input("S/N para borrar\n")
                    if delete.upper()=='S':
                        delete_query="""delete from cliente  where cod=%s"""
                        par=(cod,)
                        grabar(delete_query,par)
                        print("Registro eliminado correctamente\n")
            elif opcion==99:
                print("--Programa finalizado--")
                break
            else:
                print("No corresponde.Intente de vuelta\n")
            continue
        except(Exception, Error) as error:
            print(nombreA," No corresponde. Ingrese otra vez")
            continue 
     
except (Exception, Error) as error:
    print("Error mientras se intentó conectar a PostgreSQL:", error)
finally:
    if(connection):
        cursor.close()
        connection.close()
        print("\nLa conexión de PostgreSQL está cerrada")






