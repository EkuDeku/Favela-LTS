using System;
using Unity.Collections;
using Unity.Networking.Transport;
public struct PipelineStageCollection : INetworkPipelineStageCollection
{
    private NullPipelineStage m_NullPipelineStage;
    private ReliableSequencedPipelineStage m_ReliableSequencedPipelineStage;
    private SimulatorPipelineStage m_SimulatorPipelineStage;
    private SimulatorPipelineStageInSend m_SimulatorPipelineStageInSend;
    private UnreliableSequencedPipelineStage m_UnreliableSequencedPipelineStage;
    public int GetStageId(Type type)
    {
        if (type == typeof(NullPipelineStage))
            return 0;
        if (type == typeof(ReliableSequencedPipelineStage))
            return 1;
        if (type == typeof(SimulatorPipelineStage))
            return 2;
        if (type == typeof(SimulatorPipelineStageInSend))
            return 3;
        if (type == typeof(UnreliableSequencedPipelineStage))
            return 4;
        return -1;
    }
    public void Initialize(params INetworkParameter[] param)
    {
        for (int i = 0; i < param.Length; ++i)
        {
            if (param[i] is Unity.Networking.Transport.Utilities.ReliableUtility.Parameters)
                m_ReliableSequencedPipelineStage.Initialize((Unity.Networking.Transport.Utilities.ReliableUtility.Parameters)param[i]);
            if (param[i] is Unity.Networking.Transport.Utilities.SimulatorUtility.Parameters)
                m_SimulatorPipelineStage.Initialize((Unity.Networking.Transport.Utilities.SimulatorUtility.Parameters)param[i]);
            if (param[i] is Unity.Networking.Transport.Utilities.SimulatorUtility.Parameters)
                m_SimulatorPipelineStageInSend.Initialize((Unity.Networking.Transport.Utilities.SimulatorUtility.Parameters)param[i]);
        }
    }
    public void InvokeInitialize(int pipelineStageId, NativeSlice<byte> sendProcessBuffer, NativeSlice<byte> recvProcessBuffer, NativeSlice<byte> sharedStateBuffer)
    {
        switch (pipelineStageId)
        {
        case 0:
            m_NullPipelineStage.InitializeConnection(sendProcessBuffer, recvProcessBuffer, sharedStateBuffer);
            break;
        case 1:
            m_ReliableSequencedPipelineStage.InitializeConnection(sendProcessBuffer, recvProcessBuffer, sharedStateBuffer);
            break;
        case 2:
            m_SimulatorPipelineStage.InitializeConnection(sendProcessBuffer, recvProcessBuffer, sharedStateBuffer);
            break;
        case 3:
            m_SimulatorPipelineStageInSend.InitializeConnection(sendProcessBuffer, recvProcessBuffer, sharedStateBuffer);
            break;
        case 4:
            m_UnreliableSequencedPipelineStage.InitializeConnection(sendProcessBuffer, recvProcessBuffer, sharedStateBuffer);
            break;
        }
    }
    public InboundBufferVec InvokeSend(int pipelineStageId, NetworkPipelineContext ctx, InboundBufferVec inboundBuffer, ref bool needsResume, ref bool needsUpdate)
    {
        switch (pipelineStageId)
        {
        case 0:
            return m_NullPipelineStage.Send(ctx, inboundBuffer, ref needsResume, ref needsUpdate);
        case 1:
            return m_ReliableSequencedPipelineStage.Send(ctx, inboundBuffer, ref needsResume, ref needsUpdate);
        case 2:
            return m_SimulatorPipelineStage.Send(ctx, inboundBuffer, ref needsResume, ref needsUpdate);
        case 3:
            return m_SimulatorPipelineStageInSend.Send(ctx, inboundBuffer, ref needsResume, ref needsUpdate);
        case 4:
            return m_UnreliableSequencedPipelineStage.Send(ctx, inboundBuffer, ref needsResume, ref needsUpdate);
        }
        return inboundBuffer;
    }
    public NativeSlice<byte> InvokeReceive(int pipelineStageId, NetworkPipelineContext ctx, NativeSlice<byte> inboundBuffer, ref bool needsResume, ref bool needsUpdate, ref bool needsSendUpdate)
    {
        switch (pipelineStageId)
        {
        case 0:
            return m_NullPipelineStage.Receive(ctx, inboundBuffer, ref needsResume, ref needsUpdate, ref needsSendUpdate);
        case 1:
            return m_ReliableSequencedPipelineStage.Receive(ctx, inboundBuffer, ref needsResume, ref needsUpdate, ref needsSendUpdate);
        case 2:
            return m_SimulatorPipelineStage.Receive(ctx, inboundBuffer, ref needsResume, ref needsUpdate, ref needsSendUpdate);
        case 3:
            return m_SimulatorPipelineStageInSend.Receive(ctx, inboundBuffer, ref needsResume, ref needsUpdate, ref needsSendUpdate);
        case 4:
            return m_UnreliableSequencedPipelineStage.Receive(ctx, inboundBuffer, ref needsResume, ref needsUpdate, ref needsSendUpdate);
        }
        return inboundBuffer;
    }
    public int GetReceiveCapacity(int pipelineStageId)
    {
        switch (pipelineStageId)
        {
        case 0:
            return m_NullPipelineStage.ReceiveCapacity;
        case 1:
            return m_ReliableSequencedPipelineStage.ReceiveCapacity;
        case 2:
            return m_SimulatorPipelineStage.ReceiveCapacity;
        case 3:
            return m_SimulatorPipelineStageInSend.ReceiveCapacity;
        case 4:
            return m_UnreliableSequencedPipelineStage.ReceiveCapacity;
        }
        return 0;
    }
    public int GetSendCapacity(int pipelineStageId)
    {
        switch (pipelineStageId)
        {
        case 0:
            return m_NullPipelineStage.SendCapacity;
        case 1:
            return m_ReliableSequencedPipelineStage.SendCapacity;
        case 2:
            return m_SimulatorPipelineStage.SendCapacity;
        case 3:
            return m_SimulatorPipelineStageInSend.SendCapacity;
        case 4:
            return m_UnreliableSequencedPipelineStage.SendCapacity;
        }
        return 0;
    }
    public int GetHeaderCapacity(int pipelineStageId)
    {
        switch (pipelineStageId)
        {
        case 0:
            return m_NullPipelineStage.HeaderCapacity;
        case 1:
            return m_ReliableSequencedPipelineStage.HeaderCapacity;
        case 2:
            return m_SimulatorPipelineStage.HeaderCapacity;
        case 3:
            return m_SimulatorPipelineStageInSend.HeaderCapacity;
        case 4:
            return m_UnreliableSequencedPipelineStage.HeaderCapacity;
        }
        return 0;
    }
    public int GetSharedStateCapacity(int pipelineStageId)
    {
        switch (pipelineStageId)
        {
        case 0:
            return m_NullPipelineStage.SharedStateCapacity;
        case 1:
            return m_ReliableSequencedPipelineStage.SharedStateCapacity;
        case 2:
            return m_SimulatorPipelineStage.SharedStateCapacity;
        case 3:
            return m_SimulatorPipelineStageInSend.SharedStateCapacity;
        case 4:
            return m_UnreliableSequencedPipelineStage.SharedStateCapacity;
        }
        return 0;
    }
}
