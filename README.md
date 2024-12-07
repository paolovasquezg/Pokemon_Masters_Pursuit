# Proyecto Final: "Pokémon: Master´s Pursuit"

## Requisitos Funcionales

| **ID**   | **Descripción**                                                                                                                                                           |
|----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| RF001    | El sistema debe permitir al usuario iniciar el juego desde el menú principal, con opciones de iniciar partida.                                                            |
| RF002    | El sistema debe cargar una escena introductoria en la que el Profesor Oak explique el objetivo del juego.                                                                 |
| RF003    | El jugador debe poder moverse caminando en el bosque y alternar entre ambientes (día, tarde, noche).                                                                      |
| RF004    | Los Pokémon en el bosque deben moverse libremente con animaciones e interactuar con el entorno.                                                                           |
| RF005    | El sistema debe detectar cuando el usuario se acerque a un Pokémon y cargar la escena de captura en consecuencia.                                                        |
| RF006    | En la escena de captura, el Pokémon debe moverse de forma activa, utilizando patrones de movimiento que varíen en velocidad y dirección dependiendo de la dificultad.     |
| RF007    | En la escena de captura, el usuario debe poder tomar y lanzar Pokébolas para capturar al Pokémon, con Pokébolas que regresen a su posición inicial tras fallar.           |
| RF008    | Cuando el usuario capture un Pokémon, el sistema debe mostrar una carta con la información del Pokémon capturado.                                                        |
| RF009    | Cuando el jugador toca una carta Pokémon, regresa al bosque y se incrementa un contador de Pokémon capturados.                                                           |
| RF010    | Al capturar los 15 Pokémon requeridos, el sistema debe cargar una escena final donde el Profesor Oak entregue al usuario su Pokémon inicial.                             |

**Tabla:** Requerimientos Funcionales - Must Have

| **ID**   | **Descripción**                                                                                                                                                           |
|----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| RF011    | El sistema debe incluir una sección de ayuda y tutorial accesible desde el menú principal y entorno de juego que ayude al usuario a mejorar su experiencia.               |
| RF012    | El sistema debe disponer de un tutorial que guíe al usuario en las acciones básicas del juego, como teletransportación, interacción con Pokémon, y lanzamiento de Pokébolas.|

**Tabla:** Requerimientos Funcionales - Nice to Have

## Requisitos No Funcionales

| **ID**   | **Descripción**                                                                                                                                                           |
|----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| RNF001   | La aplicación debe ser compatible y ejecutarse de manera óptima en dispositivos Meta Quest 2.                                                                            |
| RNF002   | El entorno de juego debe cumplir con estándares de seguridad en VR, asegurando un espacio seguro para que el usuario pueda lanzar Pokébolas sin riesgo de colisión.      |
| RNF003   | Los elementos de interfaz deben mantenerse dentro del campo de visión del usuario y con una resolución adecuada para visualización en VR.                                |
| RNF004   | El sistema debe realizar transiciones suaves entre escenas, con tiempos de carga de hasta 3 segundos o pantallas de carga para mantener la inmersión del usuario.       |

**Tabla:** Requerimientos No Funcionales - Must Have

| **ID**   | **Descripción**                                                                                                                                                           |
|----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| RNF005   | La interfaz debe ser intuitiva, con menús y opciones diseñadas específicamente para VR, permitiendo fácil navegación.                                                     |
| RNF006   | La ambientación gráfica debe adaptarse al entorno (día, tarde, noche) con cambios en iluminación y efectos de sombra para mejorar la inmersión.                           |
| RNF007   | Los ambientes y las cartas informativas de los Pokémon deben tener texturas de alta calidad, y estas última tamaño legible en el dispositivo Meta Quest 2.                |
| RNF008   | Las escenas de ayuda y tutorial deben presentar la información de manera concisa, resaltando solo elementos clave para evitar sobrecarga de información.                  |

**Tabla:** Requerimientos No Funcionales - Nice to Have


## Cronograma

| **Entrega**             | **Descripción de Actividades**                                                                                                                                                                                                                                                                                          | **RF/RNF**                             | **Status**     |
|-------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------|----------------|
| Entrega 01 (15%)        | Implementación de la movilidad del jugador y los ambientes, así como el movimiento animado de los Pokémon en el bosque. Se asegura la compatibilidad en Meta Quest 2 y la fluidez en las transiciones de escena para mantener la inmersión en VR.                                                                       | RF003 RF004 RNF001 RNF004              | Completado     |
| Entrega 02 (30%)        | Desarrollo de la detección de proximidad para iniciar la escena de captura, junto con la mecánica de lanzamiento de Pokébolas. Se añadirá también el contador de Pokémon capturados y efectos gráficos en ambientes de día, tarde, y noche.                                                                          | RF005 RF007 RF009 RNF006               | Pendiente    |
| Entrega 03 (50%)        | Integración del sistema de menú principal y la escena final con el Profesor Oak. Además, se refina la interfaz para facilitar la navegación en VR.                                                                                                                              | RF001 RF002 RF010 RNF005               | Pendiente      |
| Entrega 04 (70%)        | Optimización de los patrones de movimiento de Pokémon en la escena de captura y mejoras en la interfaz visual. Se incluye el diseño del entorno de juego con consideraciones de seguridad VR.                                                                                  | RF006 RNF002 RNF003 RNF007             | Pendiente      |
| Entrega 05 (100%)       | Implementación de las cartas de información de Pokémon capturados y mejora de la sección de ayuda y tutorial para una experiencia de usuario óptima.                                                                                                                           | RF008 RF011 RF012 RNF008               | Pendiente      |

