using System;
using System.Collections;
using System.Collections.Generic;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;
using DynamicData;

class PopDetail : RxMonoBehaviour
{
    public Text liveliHood;

    public IPop pop;

    public Transform bufferContainer;
    public BufferItem defaultBufferItem;

    // Start is called before the first frame update
    void Start()
    {
        defaultBufferItem.gameObject.SetActive(false);

        dataBind.BindText(pop.liveliHood, x => x.value, liveliHood);

        dataBind.BindObservableList(pop.buffMgr.buffers.Connect().RemoveKey().AsObservableList(), OnAddBuffer, OnRemoveBuffer);
    }

    private void OnRemoveBuffer(IPopBuffer buffer)
    {
        throw new NotImplementedException();
    }

    private void OnAddBuffer(IPopBuffer buffer)
    {
        var bufferPanel = Instantiate(defaultBufferItem, bufferContainer).GetComponent<BufferItem>();
        bufferPanel.gameObject.SetActive(true);
        bufferPanel.buffer = buffer;

        var tipBuffer = bufferPanel.GetComponent<LazyUpdateTooltipTrigger>();
        tipBuffer.funcGenerateTextInfo = () =>
        {
            return new (string, string)[] { ("BodyText", buffer.desc) };
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
