using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections; // Ditambahkan untuk menggunakan Coroutine

[RequireComponent(typeof(CanvasGroup))]
public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public Transform originalParent; 

    private CanvasGroup canvasGroup;
    private Canvas mainCanvas;

    // --- BARU: Variabel untuk transisi ---
    [Tooltip("Seberapa cepat item kembali ke slotnya (dalam detik)")]
    [SerializeField] private float returnDuration = 0.3f;
    
    // Melacak coroutine yang sedang berjalan agar tidak tumpang tindih
    private Coroutine currentReturnCoroutine = null;
    // --- AKHIR BARU ---


    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        mainCanvas = GetComponentInParent<Canvas>(); 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // --- BARU: Hentikan animasi kembali jika sedang berjalan ---
        if (currentReturnCoroutine != null)
        {
            StopCoroutine(currentReturnCoroutine);
            currentReturnCoroutine = null;
        }
        // --- AKHIR BARU ---

        originalParent = transform.parent;
        transform.SetParent(mainCanvas.transform);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Logika di sini diubah:
        // Kita tidak langsung mengembalikan item,
        // tapi memulai Coroutine jika drop gagal.

        if (transform.parent == mainCanvas.transform)
        {
            // Drop gagal (di luar slot), mulai Coroutine untuk kembali
            currentReturnCoroutine = StartCoroutine(ReturnToSlot(originalParent));
        }
        else
        {
            // Drop berhasil (sudah di-parent ke slot baru oleh OnDrop)
            // Kita hanya perlu menyalakan raycast lagi
            canvasGroup.blocksRaycasts = true;
        }
    }

    // --- FUNGSI BARU: Coroutine untuk animasi kembali ---
    private IEnumerator ReturnToSlot(Transform targetParent)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;     // Posisi dunia saat ini
        Vector3 targetPosition = targetParent.position; // Posisi dunia slot tujuan

        while (elapsedTime < returnDuration)
        {
            // Hitung persentase progres (0 sampai 1)
            float t = elapsedTime / returnDuration;

            // Gunakan SmoothStep untuk transisi yang lebih halus (slow in, slow out)
            t = Mathf.SmoothStep(0f, 1f, t);

            // Gerakkan item dari posisi awal ke posisi target
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            // Tambahkan waktu yang telah berlalu
            elapsedTime += Time.deltaTime;
            
            yield return null; // Tunggu frame berikutnya
        }

        // Setelah loop selesai, pastikan item berada di posisi akhir
        transform.position = targetPosition;

        // Sekarang kembalikan parent dan reset posisi lokalnya
        transform.SetParent(targetParent);
        transform.localPosition = Vector2.zero;

        // Nyalakan kembali raycast HANYA SETELAH item kembali
        canvasGroup.blocksRaycasts = true;
        
        // Tandai coroutine sebagai selesai
        currentReturnCoroutine = null;
    }
    // --- AKHIR FUNGSI BARU ---
}