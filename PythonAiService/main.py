
from fastapi import FastAPI

app = FastAPI(
    title="AI Help Assistant - Python AI Service",
    description="Python service for our RAG application",
    version="1.0.0"
)

@app.get("/health")
async def health_check():
    return {
        "status": "Healthy",
        "service": "Python AI Service"
    }
