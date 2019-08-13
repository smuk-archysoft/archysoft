export class ApiResponse<T> {
    status: number;
    message: string;
    timestamp: number;
    model: T;
}

export class ApiResponseEmpty {
    status: number;
    description: string;
    timestamp: number;
}
