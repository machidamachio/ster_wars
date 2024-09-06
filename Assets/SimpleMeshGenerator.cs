using System.IO;
using UnityEngine;

public class SimpleMeshGenerator : MonoBehaviour
{
    /// <summary>
    /// バイナリフォーマットのSTLファイルを読み込んでMeshで返す
    /// </summary>
    /// <param name="path">STLファイルのフルパス</param>
    /// <returns>メッシュデータ</returns>
    private Mesh StlToUnityMesh(string path)
    {
        var stream = File.OpenRead(path);
        var reader = new BinaryReader(stream);

        // "任意の文字列"を読み飛ばし
        stream.Position = 80;

        // "三角形の枚数"を読み込む
        uint triangleNum = reader.ReadUInt32();

        Vector3[] vert = new Vector3[triangleNum * 3];
        int[] tri = new int[triangleNum * 3];

        int triangleIndex = 0;

        for(int i = 0; i < triangleNum; i++)
        {
            // "法線ベクトル"を読み飛ばす
            stream.Position += 12;
            // "頂点"データX, Y, Zを3個分
            vert[triangleIndex + 0] = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
            vert[triangleIndex + 1] = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
            vert[triangleIndex + 2] = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

            // 頂点を結ぶ三角形は、先ほど読み込んだ頂点番号をそのまま使う
            tri[triangleIndex] = triangleIndex++;
            tri[triangleIndex] = triangleIndex++;
            tri[triangleIndex] = triangleIndex++;

            // "未使用データ"を読み飛ばし
            stream.Position += 2;
        }

        var mesh = new Mesh();
        mesh.vertices = vert;
        mesh.triangles = tri;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return mesh;
    }

    void Start ()
    {
        string filePath = Path.Combine(Application.dataPath, "STL-FILE.stl");
        GetComponent<MeshFilter>().mesh = StlToUnityMesh(filePath);
    }   
}
