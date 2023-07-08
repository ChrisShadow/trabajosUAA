from ensurepip import version
from itertools import count
import psycopg2
from psycopg2 import connect
from psycopg2 import Error


#Base de datos
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

def dulpicadosAlu(cod):
    select_query='select * from alumnos where documento=%s'
    par=(cod,)
    alum=consultarParms(select_query,par)
    return alum

def dulpicadosNotas(documento,materia,nroparcial):
    select_query='select * from notas where documento=%s and materia=%s and nroparcial=%s'
    par=(documento,materia,nroparcial)
    alum=consultarParms(select_query,par)
    return alum

def reporteAluApe():
    sql="""select documento,apellido,nombre from alumnos order by apellido,nombre """
    datos=consultar(sql)
    if datos:
        print("\nDatos de alumnos ordenado por apellidos y nombres\n    Documento         Apellido                Nombre")
        item=0
        for d in datos:
            item+=1
            print(item,"-",d[0],"        ",d[1],"                ",d[2])

def reporteAluDocu():
    sql="""select documento,apellido,nombre from alumnos order by documento """
    datos=consultar(sql)
    if datos:
        print("\nDatos de alumnos ordenado por Nro de Ci\n      CI          Nombre                      Apellido")
        item=0
        for d in datos:
            item+=1
            print(item,"-",d[0],"        ",d[2],"                ",d[1])

def reporteNotasMate():
    sql="""select documento,apellido,nombre from alumnos order by documento """
    datos=consultar(sql)
    if datos:
        print("\nReporte de Notas Matemáticas\n     CI              Apellidos                       Nombres                                     Nota P1     Nota P2     NotaP3      Promedio")
        item=0
        for d in datos:
            item+=1
            doc=d[0]
            select_query="""select nota from notas where documento=%s and materia='Matemáticas' """
            parN=(doc,)
            notas=consultarParms(select_query,parN)
            listN=[]
            for n in notas:
                listN.append(n)
                #print(listN)
            prom=sum(listN[0]+listN[1]+listN[2])/len(listN) 
            print(item,"-",d[0],"        ",d[1],"                ",d[2],"                       ",listN[0],"        ",listN[1],"        ",listN[2],"        ",int(prom))

def reporteNotasPyt():
    sql="""select documento,apellido,nombre from alumnos order by documento """
    datos=consultar(sql)
    if datos:
        print("\nReporte de Notas Python\n     CI              Apellidos                       Nombres                                     Nota P1     Nota P2     NotaP3      Promedio")
        item=0
        for d in datos:
            item+=1
            doc=d[0]
            select_query="""select nota from notas where documento=%s and materia='Python' """
            parN=(doc,)
            notas=consultarParms(select_query,parN)
            listN=[]
            for n in notas:
                listN.append(n)
                #print(listN)
            prom=sum(listN[0]+listN[1]+listN[2])/len(listN) 
            print(item,"-",d[0],"        ",d[1],"                ",d[2],"                       ",listN[0],"        ",listN[1],"        ",listN[2],"        ",int(prom))

def csvAluApe():
    sql="""select documento,apellido,nombre from alumnos order by apellido,nombre """
    datos=consultar(sql)
    if datos:
        listaAlu=open('listaAlumnosApellidos.csv','w')
        linea="Documento;Apellido;Nombre\n"
        listaAlu.write(linea)
        for d in datos:
            linea="%s;%s;%s\n" % (d[0],d[1],d[2])
            listaAlu.write(linea)
        listaAlu.close()
        print("\nLista de alumnos ordenados por Apellido y Nombre guardado con éxito")      

def csvAluDoc():
    sql="""select documento,apellido,nombre from alumnos order by documento """
    datos=consultar(sql)
    if datos:
        listaDoc=open('listaAlumnosDocumento.csv','w')
        linea="Documento;Nombre;Apellido\n"
        listaDoc.write(linea)
        for d in datos:
            linea="%s;%s;%s\n" % (d[0],d[2],d[1])
            listaDoc.write(linea)
        listaDoc.close()
        print("\nLista de alumnos ordenados por Documento guardado con éxito")

def csvNotasMate():
    sql="""select documento,apellido,nombre from alumnos order by documento """
    datos=consultar(sql)
    if datos:
        notasM=open('notasMatematicasPromedio.csv','w')
        linea=("Documento;Apellido;Nombre;P1;P2;P3;Promedio\n")
        notasM.write(linea)
        for d in datos:
            doc=d[0]
            select_query="""select nota from notas where documento=%s and materia='Matemáticas' """
            parN=(doc,)
            notas=consultarParms(select_query,parN)
            listN=[]
            for n in notas:
                listN.append(n)
                #print(listN)
            prom=sum(listN[0]+listN[1]+listN[2])/len(listN) 
            linea='%s;%s;%s;%s;%s;%s;%s\n' % (d[0],d[1],d[2],listN[0],listN[1],listN[2],prom)
            notasM.write(linea)
        notasM.close()
        print("\nLista de alumnos con sus notas y promedio en matemáticas guardado con éxito")

def csvNotasPy():
    sql="""select documento,apellido,nombre from alumnos order by documento """
    datos=consultar(sql)
    if datos:
        notasP=open('notasPythonPromedio.csv','w')
        linea=("Documento;Apellido;Nombre;P1;P2;P3;Promedio\n")
        notasP.write(linea)
        for d in datos:
            doc=d[0]
            select_query="""select nota from notas where documento=%s and materia='Python' """
            parN=(doc,)
            notas=consultarParms(select_query,parN)
            listN=[]
            for n in notas:
                listN.append(n)
                #print(listN)
            prom=sum(listN[0]+listN[1]+listN[2])/len(listN) 
            linea='%s;%s;%s;%s;%s;%s;%s\n' % (d[0],d[1],d[2],listN[0],listN[1],listN[2],prom)
            notasP.write(linea)
        notasP.close()
        print("\nLista de alumnos con sus notas y promedio en Python guardado con éxito")



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

    #Alu
    
    while True:
        nombreA= input('Ingrese el archivo alumnos.csv(Enter para salir): ')
        if nombreA=='': 
            print("**Operación cancelada**") 
            break
        try:
            if len(nombreA) < 1 : nombreA='alumnos.csv',
            archivo= open(nombreA, encoding="utf-8")
            con=0
            item=0
            print("Nombre|Apellido|Documento")
            for linea in archivo:
                con+=1
                if con>1:
                    item+=1
                    linea=linea.rstrip()
                    wds=linea.split(';')
                    for opcion in wds: 
                        opcion=wds[0]+'-'+wds[1]+'-'+wds[2]
                    print(item,"-",opcion)
                    nom=wds[0]
                    ape=wds[1]
                    doc=int(wds[2])
                    existe=dulpicadosAlu(doc)
                    if not existe:
                        insert_query="""insert into alumnos (documento,nombre,apellido) values(%s,%s,%s) """
                        inser_par=(doc,nom,ape)
                        grabar(insert_query,inser_par)
                    else:
                        print("Registro existente en la base de datos")
            print("\nRegistro alumno insertado correctamente\n")
            archivo.close()
            break 
        except (Exception, Error) as error:
            print(nombreA," No corresponde. Ingrese otra vez. ",error)
            continue
    
    #Notas Mate
    while True:
        nombreNM= input('Ingrese el archivo notasMatematicas.csv(Enter para salir): ')
        if nombreNM=='': 
            print("**Operación cancelada**") 
            break
        try:
            if len(nombreNM) < 1 : nombreNM='notasMatematicas.csv',
            archivoM= open(nombreNM, encoding="utf-8")
            con=0
            item=0
            print("Documento|1p|2p|2p")
            for linea in archivoM:
                con+=1
                if con>1:
                    item+=1
                    linea=linea.rstrip()
                    wds=linea.split(';')
                    for opcion in wds: 
                        opcion=wds[0]+'-'+wds[1]+'-'+wds[2]+'-'+wds[3]
                    print(item,"-",opcion)
                    doc=int(wds[0])
                    np1=int(wds[1])
                    np2=int(wds[2])
                    np3=int(wds[3])
                    lineaN=[np1,np2,np3]
                    ind=1
                    for nm in lineaN:
                        materia="Matemáticas"
                        nroparcial=ind
                        nota=int(nm)
                        existe=dulpicadosNotas(doc,materia,nroparcial)
                        if not existe:
                            insert_query="""insert into notas (materia,documento,nroparcial,nota) values(%s,%s,%s,%s) """
                            inser_par=(materia,doc,nroparcial,nota)
                            grabar(insert_query,inser_par)
                        else:
                            print("Registro existente en la base de datos")
                        ind+=1
            print("\nRegistro notas de matemática insertado correctamente\n")
            archivoM.close()  
            break
        except (Exception, Error) as error:
            print(nombreA," No corresponde. Ingrese otra vez. ",error)
            continue


    #Notas Pyth
    while True:
        nombreNP= input('Ingrese el archivo notasPython.csv(Enter para salir): ')
        if nombreNP=='': 
            print("**Operación cancelada**") 
            break
        try:
            if len(nombreNP) < 1 : nombreNP='notasPython.csv',
            archivoP= open(nombreNP, encoding="utf-8")
            con=0
            item=0
            print("Documento|1p|2p|2p")
            for linea in archivoP:
                con+=1
                if con>1:
                    item+=1
                    linea=linea.rstrip()
                    wds=linea.split(';')
                    for opcion in wds: 
                        opcion=wds[0]+'-'+wds[1]+'-'+wds[2]+'-'+wds[3]
                    print(item,"-",opcion)
                    doc=int(wds[0])
                    np1=int(wds[1])
                    np2=int(wds[2])
                    np3=int(wds[3])
                    lineaN=[np1,np2,np3]
                    ind=1
                    for nm in lineaN:
                        materia="Python"
                        nroparcial=ind
                        nota=int(nm)
                        existe=dulpicadosNotas(doc,materia,nroparcial)
                        if not existe:
                            insert_query="""insert into notas (materia,documento,nroparcial,nota) values(%s,%s,%s,%s) """
                            inser_par=(materia,doc,nroparcial,nota)
                            grabar(insert_query,inser_par)
                        else:
                            print("Registro existente en la base de datos")
                        ind+=1
            print("\nRegistro notas python insertado correctamente\n")
            archivoP.close()  
            break
        except (Exception, Error) as error:
            print(nombreA," No corresponde. Ingrese otra vez. ",error)
            continue

    while True:
        nombreM= input('Ingrese el archivo reportes.txt(Enter para salir): ')
        if nombreM=='': 
            print("**redirigiendo**") 
            break
        try:
            if len(nombreM) < 1 : nombreM='reportes.txt',
            while not False:
                archivo= open(nombreM, encoding="utf-8")
                menu=[]
                print("\n--MENÚ DE OPERACIONES--")
                for linea in archivo:
                    linea=linea.rstrip()
                    wds=linea.split(':')
                    for opcion in wds: 
                        opcion=wds[0]+'-'+wds[1]
                        menu.append(opcion)   
                    print(" ",opcion)
                dato=input("\nIngrese una opción a ejecutar:")
                try:
                    opcion=int(dato)
                    if opcion==1:
                        reporteAluApe()
                    elif opcion==2:
                        reporteAluDocu()
                    elif opcion==3:
                        reporteNotasMate()
                    elif opcion==4:
                        reporteNotasPyt()
                    elif opcion==5:
                        csvAluApe()
                    elif opcion==6:
                        csvAluDoc()
                    elif opcion==7:
                        csvNotasMate()
                    elif opcion==8:
                        csvNotasPy()
                    elif opcion==99:
                        print("--Saliendo del menú--\n")
                        break
                    else:
                        print(opcion," no corresponde.Intente de vuelta\n")
                        continue
                except (Exception, Error) as error:
                    print("\nDebe ser solo número. Intente de vuelta\n\n",error)
                    continue
        except (Exception, Error) as error:
            print(nombreM,"No corresponde. Ingrese otra vez. ",error)
            continue

except (Exception, Error) as error:
    print("Error mientras se intentó conectar a PostgreSQL:", error)
finally:
    if(connection):
        cursor.close()
        connection.close()
        print("\nPROGRAMA FINALIZADO.\nLa conexión de PostgreSQL está cerrada.")
