export interface Informe {
    id: number;
    tipo: number;
    subestacionId: number;
    lineaTransmisionId: number;
    datosDeLineaId: number;
    datosDeLinea: {
        id: number;
        ot: string;
        aviso: string;
        sap: string;
        distancia: string;
        funcion: string;
        zona: string;
    };
    datosGeneralesId: number;
    datosGenerales: {
        id: number;
        evento: string;
        fecha: Date;
        hora: {
            ticks: number;
        };
        subestacion: string;
        lt: string;
        equipo: string;
    };
    teleproteccionId: number;
    teleproteccion: {
        id: number;
        tX_TEL: string;
        rX_TEL: string;
        tiempoMPLS: string;
    };
    distanciaDeFallaId: number;
    distanciaDeFalla: {
        id: number;
        distanciaKM: string;
        distanciaPorcentaje: string;
        distanciaReportada: string;
        distanciaDobleTemporal: string;
        error: string;
        error_Doble: string;
    };
    tiemposDeDisparoId: number;
    tiemposDeDisparo: {
        id: number;
        r: string;
        s: string;
        t: string;
        reserva: string;
    };
    corrientesDeFallaId: number;
    corrientesDeFalla: {
        id: number;
        realIR: string;
        realIS: string;
        realIT: string;
        acumuladaR: string;
        acumuladaS: string;
        acumuladaT: string;
    };
    estado: number;
}