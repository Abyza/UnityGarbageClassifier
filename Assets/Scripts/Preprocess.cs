﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Preprocess : MonoBehaviour {

    RenderTexture renderTexture;
    Vector2 scale = new Vector2(1, 1);
    Vector2 offset = Vector2.zero;

    UnityAction<byte[]> callback;

    public RawImage previewImage;

    public void ScaleAndCropImage(WebCamTexture webCamTexture, int desiredSize, UnityAction<byte[]> callback) {

        this.callback = callback;

        if (renderTexture == null) {
            renderTexture = new RenderTexture(desiredSize, desiredSize,0,RenderTextureFormat.ARGB32);
        }

        scale.x = (float)webCamTexture.height / (float)webCamTexture.width;
        offset.x = (1 - scale.x) / 2f;
        Graphics.Blit(webCamTexture, renderTexture, scale, offset);
        AsyncGPUReadback.Request(renderTexture, 0, TextureFormat.RGB24, OnCompleteReadback);
        previewImage.texture = renderTexture;
    }

    void OnCompleteReadback(AsyncGPUReadbackRequest request) {

        if (request.hasError) {
            Debug.Log("GPU readback error detected.");
            return;
        }

        callback.Invoke(request.GetData<byte>().ToArray());
    }
}