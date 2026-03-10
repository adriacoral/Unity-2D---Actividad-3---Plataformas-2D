using UnityEngine;

// 📦 SCRIPT 3: Permite saltar desde abajo y subir a la plataforma
// Pon este script en el GameObject de la plataforma
// ⚠️ Este script configura automáticamente los componentes necesarios

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlatformEffector2D))]
public class PlatformOneWay : MonoBehaviour
{
    void Awake()
    {
        // Configuramos el Collider2D para que use el efector
        Collider2D col = GetComponent<Collider2D>();
        col.usedByEffector = true;

        // Configuramos el PlatformEffector2D (Unity lo gestiona solo)
        PlatformEffector2D efector = GetComponent<PlatformEffector2D>();
        efector.useOneWay = true;        // activa el modo "solo desde arriba"
        efector.surfaceArc = 100f;       // ✅ FIX: 60-100 = solo sólida por arriba. 180 bloqueaba por todos lados
        efector.rotationalOffset = 0f;
    }
}
