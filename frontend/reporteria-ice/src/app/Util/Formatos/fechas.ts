export function formatearFechaHora(fechaHora: string): string {
    if (!fechaHora) return '';
    const date = new Date(fechaHora);
    const opcionesFecha = { year: 'numeric', month: '2-digit', day: '2-digit' } as const;
    const opcionesHora = { hour: '2-digit', minute: '2-digit', second: '2-digit' } as const;
    const fechaFormateada = date.toLocaleDateString('es-ES', opcionesFecha);
    const horaFormateada = date.toLocaleTimeString('es-ES', opcionesHora);
    return `${fechaFormateada} ${horaFormateada}`;
}

export function obtenerFechaHoraLocalISO(): string {
    const now = new Date();
    const offset = now.getTimezoneOffset();
    const adjustedDate = new Date(now.getTime() - offset * 60 * 1000);
    return adjustedDate.toISOString().slice(0, -1);
}