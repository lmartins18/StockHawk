import { AxiosError } from "axios";

interface ApiErrorResponse {
  message?: string;
  title?: string;
}

export const handleApiError = (
  error: AxiosError,
  setError: React.Dispatch<React.SetStateAction<string | null>>
) => {
  const defaultErrorMessage = "An unexpected error occurred";

  if (error.response) {
    const errorResponse = error.response.data as ApiErrorResponse;
    const errorMessage = errorResponse.title ?? errorResponse.message ?? defaultErrorMessage;

    setError(errorMessage);

  } else {
    setError(defaultErrorMessage);
  }

  console.error("API error:", error);
};
