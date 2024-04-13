org $81800D
    JSR SaveSlotRotation

org $81FF60
SaveSlotRotation:
    LDA $0952 : CMP #$0002 : BMI .inc
    LDA #$FFFF
  .inc
    INC : STA $0952
    AND #$0003
    RTS