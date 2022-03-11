using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;
using DynamicData;

class PopDetail : RxMonoBehaviour
{
    public Text popCount;
    public Text popTax;
    public Text popLiveliHood;
    public Text farmTotal;
    public Text farmAverage;

    public IPop pop;

    public Transform bufferContainer;
    public BufferItem defaultBufferItem;

    // Start is called before the first frame update
    void Start()
    {
        defaultBufferItem.gameObject.SetActive(false);

        dataBind.BindText(pop, x => x.num, popCount);
        dataBind.BindText(pop, x => x.farmTotal, farmTotal);
        dataBind.BindText(pop, x => x.farmAverage, farmAverage);
        dataBind.BindText(pop.taxSource, x => x.value, popTax);
        dataBind.BindText(pop.liveliHood, x => x.value, popLiveliHood);

        dataBind.BindObservableList(pop.buffMgr.buffers.Connect().RemoveKey().AsObservableList(), OnAddBuffer, OnRemoveBuffer);


        var tipTax = popTax.GetComponent<LazyUpdateTooltipTrigger>();
        tipTax.funcGenerateTextInfo = () =>
        {
            return new (string, string)[] { ("BodyText", 
                $"BaseValue {pop.taxSource.baseValue}" 
                + "\n\n"
                + string.Join("\n", pop.taxSource.effects.Items.Select(x => $"{x.from.GetType().Name} {x.value}"))) };
        };

        var tipLive = popLiveliHood.GetComponent<LazyUpdateTooltipTrigger>();
        tipLive.funcGenerateTextInfo = () =>
        {
            return new (string, string)[] { ("BodyText", string.Join("\n", pop.liveliHood.effects.Items.Select(x=> $"{x.from.GetType().Name} {x.value}"))) };
        };
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
