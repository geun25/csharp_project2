namespace WaferLineCommLib
{
    public enum MsgType
    {
        MSG_CF_ADDSI,//central -> factory add server information
        MSG_CF_ADDWF,
        MSG_CF_ADDPR,
        MSG_CF_SETSP,
        MSG_CF_SETDP,
        MSG_FC_ADDLN, // factory -> central line 추가메시지
        MSG_FC_ADDWF, // factory -> central wafer 추가메시지
        MSG_FC_ADDPR,
        MSG_FC_SETSP,
        MSG_FC_SETDR,
        MSG_FC_ENDPR,
        MSG_FC_ENDCO
    }
}
