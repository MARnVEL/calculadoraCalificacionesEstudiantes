
/*
Esta aplicación de consola de C# está diseñada para:
- Utilizar arrays para almacenar los nombres y las notas de tareas de los estudiantes.
- Utilizar una sentencia `foreach` para iterar a través de los nombres de los estudiantes
como un bucle externo.
- Utilizar una sentencia `if` dentro del bucle externo para identificar el nombre del
estudiante actual y acceder a las notas de las tareas del estudiante.
- Utilizar una sentencia `foreach` dentro del bucle externo para iterar a través del array
de puntajes de tareas y sumar los valores.
- Utilizar un algoritmo dentro del bucle externo para calcular el puntaje promedio de
exámenes para cada estudiante.
- Utilizar una construcción `if-elseif-else` dentro del bucle externo para evaluar el
puntaje promedio de exámenes y asignar una puntuación de letra automáticamente.
- Integrar las calificaciones de  puntos extra cuando se calcula el puntaje final y la puntuación de letra  del estudiante como sigue:
    - detectar asignaciones de puntos extra según la cantidad de elementos en el array de
    puntuaciones del estudiante.
    - dividir el valor de los puntos extra asignados por 10 antes de sumar los puntos 
    extra a la suma de las notas de exámenes.
- Utilizar el siguiente formato de reporte para mostrar las notas de los estudiantes:

Estudiante    Nota del exámen   Promedio general  Puntos extra

Sophia          92.2            95.88   A          92 (3.68 pts)

*/

int notasDeExamenes = 5;

string[] nombresEstudiantes = ["Sophia", "Andrew", "Emma", "Logan"];

int[] notasSophia = [90, 86, 87, 98, 100, 94, 90];
int[] notasAndrew = [92, 89, 81, 96, 90, 89];
int[] notasEmma = [90, 85, 87, 98, 68, 89, 89, 89];
int[] notasLogan = [90, 95, 87, 88, 96, 96];

int[] puntajesEstudiantes = new int[10];

string NotaLetraEstudianteActual = "";

// mostrar la fila de la cabecera para puntuaciones/notas
Console.Clear();
Console.WriteLine(
    "Estudiante\tNota de Exámen\tPromedio General\tPuntos Extra\n"
);

/*
El bucle foreach externo se utiliza para:
- Iterar a través de los nombres de los estudiantes
- Asignar notas de un estudiante al array puntajesEstudiantes.
- Sumar las notas asignadas (bucle foreach interno)
- Calcular la nota numérica y de letra.
- Escribir el reporte de información de puntajes
*/
foreach (string nombre in nombresEstudiantes)
{
    string estudianteActual = nombre;

    if (estudianteActual == "Sophia")
        puntajesEstudiantes = notasSophia;

    else if (estudianteActual == "Andrew")
        puntajesEstudiantes = notasAndrew;

    else if (estudianteActual == "Emma")
        puntajesEstudiantes = notasEmma;

    else if (estudianteActual == "Logan")
        puntajesEstudiantes = notasLogan;

    int tareasCalificadas = 0;
    int tareasDePuntosExtraCalificadas = 0;

    int sumaPuntosDeExamenes = 0;
    int sumaCalificacionDePuntosExtra = 0;

    decimal calificacionActualEstudiante = 0;
    decimal puntajeExamenEstudianteActual = 0;
    decimal calificacionPuntosExtraEstudianteActual = 0;

    /*
    el bucle foreach interno suma las notas asignadas.
    Las tareas de puntaje extra asignadas valen 10% de un puntaje de exámen.
    */
    foreach (int puntaje in puntajesEstudiantes)
    {
        tareasCalificadas += 1;

        if (tareasCalificadas <= notasDeExamenes) {
            sumaPuntosDeExamenes += puntaje;
        }
        else {
            tareasDePuntosExtraCalificadas += 1;
            sumaCalificacionDePuntosExtra += puntaje;
        }
    }

    // calificacionActualEstudiante = (decimal)(sumAssignmentScores) / notasDeExamenes;
    puntajeExamenEstudianteActual = (decimal)(sumaPuntosDeExamenes) / notasDeExamenes;
    calificacionPuntosExtraEstudianteActual = (decimal)(sumaCalificacionDePuntosExtra) / tareasDePuntosExtraCalificadas;

    calificacionActualEstudiante = (decimal)((decimal)sumaPuntosDeExamenes + ((decimal)sumaCalificacionDePuntosExtra / 10)) / notasDeExamenes;

    if (calificacionActualEstudiante >= 97)
        NotaLetraEstudianteActual = "A+";

    else if (calificacionActualEstudiante >= 93)
        NotaLetraEstudianteActual = "A";

    else if (calificacionActualEstudiante >= 90)
        NotaLetraEstudianteActual = "A-";

    else if (calificacionActualEstudiante >= 87)
        NotaLetraEstudianteActual = "B+";

    else if (calificacionActualEstudiante >= 83)
        NotaLetraEstudianteActual = "B";

    else if (calificacionActualEstudiante >= 80)
        NotaLetraEstudianteActual = "B-";

    else if (calificacionActualEstudiante >= 77)
        NotaLetraEstudianteActual = "C+";

    else if (calificacionActualEstudiante >= 73)
        NotaLetraEstudianteActual = "C";

    else if (calificacionActualEstudiante >= 70)
        NotaLetraEstudianteActual = "C-";

    else if (calificacionActualEstudiante >= 67)
        NotaLetraEstudianteActual = "D+";

    else if (calificacionActualEstudiante >= 63)
        NotaLetraEstudianteActual = "D";

    else if (calificacionActualEstudiante >= 60)
        NotaLetraEstudianteActual = "D-";

    else
        NotaLetraEstudianteActual = "F";

    Console.WriteLine($"{estudianteActual}\t\t{puntajeExamenEstudianteActual}\t\t{calificacionActualEstudiante}\t{NotaLetraEstudianteActual}\t\t{calificacionPuntosExtraEstudianteActual} ({(((decimal)sumaCalificacionDePuntosExtra / 10) / notasDeExamenes)} pts)");
}

// requerido para ejecutar en VS Code (Mantiene las ventanas de salida abiertas para revisar los resultados)
Console.WriteLine("\n\rPresione la tecla Enter para continuar");
Console.ReadLine();
