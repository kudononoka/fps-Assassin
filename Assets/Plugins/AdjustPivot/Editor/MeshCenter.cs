using UnityEngine;
using UnityEditor;

public class MeshCenter
{

    //　自前のメニューと項目を作成
    [MenuItem("Window/MeshCenter", false, 1000)]
    static void MeshCenterProc()
    {
        if (Selection.activeGameObject == null)
            return;

        GameObject centerTarget = new GameObject("CenterTarget");

        var vec3 = Selection.activeGameObject.GetComponent<Renderer>().bounds.center;
        Selection.activeGameObject.transform.position = -vec3;
        centerTarget.transform.SetParent(Selection.activeGameObject.transform);

        Selection.activeGameObject = centerTarget;
    }
}
