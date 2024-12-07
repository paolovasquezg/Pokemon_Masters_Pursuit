using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControll2 : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Velocidad de movimiento
    private float rotationSpeed = 120f; // Velocidad de giro
    public float idleTime = 2.0f; // Tiempo en estado Idle
    public float maxWalkDistance = 5.0f; // Distancia máxima a caminar
    private float maxWalkTime = 1.0f; // Tiempo máximo caminando

    private Animator animator;
    private Vector3 targetDirection;
    private Vector3 startPosition;
    private float idleTimer = 0f;
    private bool isRotating = false;

    private float walkDistance; // Distancia aleatoria asignada
    private float walkTimer; // Temporizador de caminata
    private bool isWalkTimerActive = false; // Indicador para activar el temporizador de caminata

    private enum State { Idle, Rotating, Walking }
    private State currentState = State.Idle;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetIdleState();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                UpdateIdle();
                break;

            case State.Rotating:
                UpdateRotating();
                break;

            case State.Walking:
                UpdateWalking();
                break;
        }
    }

    private void SetIdleState()
    {
        currentState = State.Idle;
        idleTimer = idleTime;

        // Detener la animación de Walking y asegurar que no se haga bucle
        animator.SetBool("IsWalking", false);

        // Desactivar el temporizador de caminata si está activo
        isWalkTimerActive = false;
    }

    private void UpdateIdle()
    {
        idleTimer -= Time.deltaTime;

        if (idleTimer <= 0f)
        {
            StartRotating();
        }
    }

    private void StartRotating()
    {
        currentState = State.Rotating;
        isRotating = true;

        targetDirection = Random.insideUnitSphere;
        targetDirection.y = 0;
        targetDirection.Normalize();
    }

    private void UpdateRotating()
    {
        if (isRotating)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 5f)
            {
                isRotating = false;
                StartWalking();
            }
        }
    }

    private void StartWalking()
    {
        currentState = State.Walking;
        startPosition = transform.position;

        // Determinar una distancia aleatoria dentro del rango
        walkDistance = Random.Range(1.0f, maxWalkDistance);

        // Inicializar el temporizador de caminata y activarlo
        walkTimer = 0f;
        isWalkTimerActive = true;

        // Activar la animación de "Walking" y permitir bucle
        animator.SetBool("IsWalking", true);
    }

    private void UpdateWalking()
    {
        Vector3 movement = transform.forward * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Verificar si hemos alcanzado la distancia o el tiempo máximo de caminata
        if (Vector3.Distance(startPosition, transform.position) >= walkDistance)
        {
            // Si se ha completado la distancia, desactivar el temporizador
            isWalkTimerActive = false;
            SetIdleState();
        }
        else if (isWalkTimerActive)
        {
            // Si el temporizador de caminata está activo, incrementar el walkTimer
            walkTimer += Time.deltaTime;

            // Si el tiempo máximo ha pasado, forzar transición a Idle
            if (walkTimer >= maxWalkTime)
            {
                Debug.Log("Tiempo máximo alcanzado. Forzando transición a Idle.");
                SetIdleState();
            }
        }
    }
}
