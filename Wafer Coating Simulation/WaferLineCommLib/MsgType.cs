namespace WaferLineCommLib
{
    public enum MsgType
    {
        MSG_CF_ADDSI,//central -> factory add server information
        MSG_FC_ADDLN, // factory -> central line 추가메시지
        MSG_FC_ADDWF // factory -> central wafer 추가메시지
    }
}
