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
    select_query="""select * from usuario order by apellido,nombre"""
    registros=consultar(select_query)
    print("Datos del usuario\n")
    for r in registros:
        idusuario=r[0]
        nombre=r[1]
        apellido=r[2]
        rol=r[3]
        est=r[4]
        print(idusuario,",",nombre,",",apellido,",",rol,",",est)
    return

def busqueda(idusuario):
    par=(idusuario,)
    select_query="""select * from usuario where idusuario=%s"""
    usu=consultarParms(select_query,par)
    return usu

def buscardesplegarDatos():
    idusuario=input("Ingrese el nro CI del usuario(ID)\n")
    user=busqueda(idusuario)
    if user:
        idusuario=user[0][0]
        nombre=user[0][1]
        apellido=user[0][2]
        rol=user[0][3]
        estado=user[0][4]
        print("Datos del usuario\n")
        print("Id Usuario:",idusuario,"\nNombre:",nombre,"\nApellido:",apellido,"\nRol:",rol,"\nEstado:",estado,"\n")
    else:
        print("No existe un usuario con cód:",idusuario)
    return user



try:
    connection= psycopg2.connect(user='postgres',
    password='123ABC459',
    host='127.0.0.1',
    port="5432",
    database='usuarios') 
    cursor=connection.cursor()

    #Postg version
    cursor.execute('select version();')
    version=cursor.fetchone()
    print("Conectado a -", version, "\n")

    dicOpc={1:'Agregar',2:'Modificar Rol',3:'Activar',4:'Desactivar',99:'Fin'}
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
              print("\nAgregando datos a la tupla\n")
              ci=input("Ingrese CI del usuario:\n")
              nom=input("Ingrese el nombre:\n")
              ape=input("Ingrese el apellido:\n")
              rol=input("Ingrese el rol(A-Administrador;S-Staff;U-Usuario General):")
              while(rol!="A" and rol!="S" and rol!="U"):
                print("No corresponde,intente de vuelta")
                rol=input("Ingrese el rol(A-Administrador;S-Staff;U-Usuario General):")
                if rol=="A" or rol=="S" or rol=="U":
                    break
              print("Agregando Activo a estado...")
              estado="A"
              insert_query="""insert into usuario (idusuario, nombre, apellido, rol, estado) values (%s,%s,%s,%s,%s)"""
              par=(ci,nom,ape,rol,estado)
              grabar(insert_query,par)
              print("Registro insertado correctamente\n")

            elif opcion==2:
                user=buscardesplegarDatos()
                if user:
                    print("Ingrese los nuevos datos")
                    rolN=input("Ingrese el nuevo rol(A-Administrado;S-Staff;U-Usuario General):\n")
                    while(rolN!="A" and rolN!="S" and rolN!="U"):
                        print("No corresponde")
                        rolN=input("Ingrese el nuevo rol(A-Administrado;S-Staff;U-Usuario General):\n")
                        if rolN=="A" or rolN=="S" or rolN=="U":
                            break
                    idusuario=user[0][0]
                    rol=user[0][3]
                    if rol!=rolN:
                        rol=rolN
                        upd_query="""update usuario set rol=%s where idusuario=%s"""
                        par=(rol,idusuario)
                        grabar(upd_query,par)
                        print("Registro actualizado correctamente\n")
                    else:
                        print("Intente otra opción")
                else:
                    print("Reintentar operación.")

            elif opcion==3:
                user=buscardesplegarDatos()
                if user:
                    id=user[0][0]
                    nombre=user[0][1]
                    apellido=user[0][2]
                    rol=user[0][3]
                    estado=user[0][4]
                    if estado=="A":
                        print("El estado se encuentra activo")
                        continue
                    elif estado=="I":
                        print("El estado se encuentra inactivo\n")
                        estN=input("Ingrese A para pasar el estado a Activo:\n")
                        while(estN!="A"):
                            estN=input("Ingrese A para pasar el estado a Activo:\n")
                            if estN=="A":
                                break
                        upd_query="""update usuario set estado=%s where idusuario=%s"""
                        par=(estN,id)
                        grabar(upd_query,par)
                        print("Registro actualizado correctamente\n")
            elif opcion==4:
                user=buscardesplegarDatos()
                if user:
                    id=user[0][0]
                    nombre=user[0][1]
                    apellido=user[0][2]
                    rol=user[0][3]
                    estado=user[0][4]
                    if estado=="I":
                        print("El estado se encuentra inactivo")
                        continue
                    elif estado=="A":
                        print("El estado se encuentra activo\n")
                        act=input("S/N para actualizar\n")
                        if act.upper()=='S':
                            estN=input("Ingrese I para pasar el estado a Inactivo:\n")
                            while(estN!="I"):
                                estN=input("Ingrese I para pasar el estado a Inactivo:\n")
                                if estN=="I":
                                    break
                            upd_query="""update usuario set estado=%s where idusuario=%s"""
                            par=(estN,id)
                            grabar(upd_query,par)
                            print("Registro actualizado correctamente\n")
            elif opcion==99:
                print("--Programa finalizado--")
                break
            else:
                print("No corresponde.Intente de vuelta\n")
            continue
        except(Exception, Error) as error:
            print("Debe ser solo número. Intente de vuelta\n\n",error)
            continue 
     
except (Exception, Error) as error:
    print("Error mientras se intentó conectar a PostgreSQL:", error)
finally:
    if(connection):
        cursor.close()
        connection.close()
        print("\nLa conexión de PostgreSQL está cerrada")
