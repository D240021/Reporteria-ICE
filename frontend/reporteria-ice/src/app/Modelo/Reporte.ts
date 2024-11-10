export interface Reporte {
    id: number,
    mapaDeDescargas?: string,
    observaciones?: string,
    evidencia?: string,
    observacionesTecnicoLinea?: string,
    causas?: string,
    fechaHora?: Date | null | string,
    informeV1Id: number,
    informeV2Id: number,
    informeV3Id: number,
    informeV4Id: number,
    usuarioSupervisorId: number,
    tecnicoLineaId: number,
    estado: 0
}

