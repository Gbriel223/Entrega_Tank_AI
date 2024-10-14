using UnityEngine;

public class DiaENoite : MonoBehaviour
{
    public Light directionalLight;  // A luz direcional (sol)
    public float dayDuration = 120f;  // Duração do ciclo dia/noite (em segundos)
    public Gradient lightColor;  // Gradiente para mudar a cor da luz

    private float timeOfDay;  // Tempo atual no ciclo

    void Update()
    {
        // Atualiza o tempo do ciclo
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay > 1f)
        {
            timeOfDay = 0f;  // Reinicia o ciclo
        }

        // Calcula o ângulo de rotação para simular o sol se movendo
        float sunAngle = Mathf.Lerp(0, 360, timeOfDay);
        directionalLight.transform.rotation = Quaternion.Euler(sunAngle - 90f, 170f, 0);

        // Ajusta a cor da luz com base no tempo
        directionalLight.color = lightColor.Evaluate(timeOfDay);
    }
}
