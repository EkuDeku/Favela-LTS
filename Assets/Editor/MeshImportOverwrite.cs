using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshImportOverwrite : AssetPostprocessor
{

    private void OnPreprocessModel()
    {

        ModelImporter importer = (ModelImporter)assetImporter;
        importer.materialImportMode = ModelImporterMaterialImportMode.None;
        importer.isReadable = true;

    }

}
