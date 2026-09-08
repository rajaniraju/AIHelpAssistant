# AIHelpAssistant

AI-powered support assistant built with **C# and ASP.NET Core**.

The project explores how Generative AI can be combined with application-specific information to provide more relevant, contextual, and grounded answers to support questions.

The long-term goal is to evolve AIHelpAssistant into an intelligent support platform capable of working with **documents, images, natural language, and application knowledge**.

---

## Purpose

Traditional AI assistants primarily rely on the knowledge available to the underlying language model. AIHelpAssistant is being developed to go beyond that approach by allowing the application to provide its own trusted context when generating answers.

A major part of the project is the planned implementation of **Retrieval-Augmented Generation (RAG)**.

The RAG workflow will allow the application to:

1. Receive a user's question.
2. Understand the question and identify relevant information.
3. Search the application's knowledge base.
4. Retrieve relevant context.
5. Provide the context to the Generative AI model.
6. Generate an answer based on the retrieved information.

This approach is intended to make responses more **relevant, consistent, and grounded in application-specific knowledge**.

---

## Current Focus

The current implementation establishes the foundation for the AI support platform.

Current development includes:

* C# and ASP.NET Core API development
* Auth0 authentication
* JWT-based authorization
* Protected API endpoints
* Generative AI API integration
* Service-based application architecture
* API testing and troubleshooting
* AI-assisted development using tools such as **Codex and Claude**

The project is being developed incrementally, with additional intelligent processing capabilities planned for future iterations.

---

## AI Capabilities Roadmap

AIHelpAssistant is intended to evolve beyond a basic AI question-and-answer application.

### 1. Document Processing & Verification

The application will explore the use of **Azure OCR / Azure AI document-processing capabilities** to process uploaded documents.

The objective is to extract text and relevant information from documents and use the extracted information for verification and downstream processing.

Planned workflow:

```text
Document
   │
   ▼
Azure OCR
   │
   ▼
Text / Information Extraction
   │
   ▼
Document Verification
   │
   ▼
Validated Information
```

---

### 2. Computer Vision

Future development will explore **computer vision** capabilities for analyzing images and documents.

This can extend the application beyond text-based processing by allowing it to work with visual information.

Potential applications include:

* Image analysis
* Document image analysis
* Identification of visual information
* Image-based verification workflows

---

### 3. Natural Language Processing

**Natural Language Processing (NLP)** will be explored to improve the application's ability to understand and process natural-language information.

Potential capabilities include:

* Question understanding
* Text classification
* Entity extraction
* Semantic analysis
* Processing information extracted from documents

---

### 4. Retrieval-Augmented Generation

The next major stage is implementing a **RAG pipeline**.

The planned architecture will allow information processed by the application to become part of a searchable knowledge base.

```text
Documents / Application Data
             │
             ▼
       Text Processing
             │
             ▼
        Embeddings
             │
             ▼
       Vector Database
             │
             ▼
      Semantic Retrieval
             │
             ▼
      Relevant Context
             │
             ▼
      Generative AI
             │
             ▼
      Grounded Answer
```

The vector database will provide a way to store embeddings and retrieve information based on semantic similarity.

The RAG workflow will then use the retrieved information as context for the Generative AI model.

---

## Long-Term Architecture

The long-term vision is to bring these capabilities together into a single intelligent support workflow.

```text
                         AIHelpAssistant
                                │
              ┌─────────────────┼─────────────────┐
              │                 │                 │
          Documents           Images        User Questions
              │                 │                 │
              ▼                 ▼                 ▼
        Azure OCR        Computer Vision          NLP
              │                 │                 │
              └─────────────────┼─────────────────┘
                                │
                                ▼
                     Processed Application Data
                                │
                                ▼
                         Knowledge Base
                                │
                                ▼
                       Embeddings / Vector DB
                                │
                                ▼
                              RAG
                                │
                                ▼
                         Generative AI
                                │
                                ▼
                       Context-Aware Answer
```

The goal is to create an application that can understand **documents, images, and natural-language questions**, retrieve relevant information, and use that information to provide grounded AI-assisted responses.

---

## Technology
### Frontend  - planned
- React
- TypeScript
- JavaScript
  
### Backend

* C#
* ASP.NET Core
* .NET
* REST APIs
* Entity Framework Core

### Data

* SQL
* Relational database concepts
* Vector database / vector search — planned

### Authentication & Security

* Auth0
* JWT / Bearer Authentication

### AI

* Generative AI APIs
* Retrieval-Augmented Generation — planned
* Embeddings and vector search — planned
* Azure OCR / document processing — planned
* Natural Language Processing — planned
* Computer Vision — planned

### Development

* Git
* GitHub
* Codex
* Claude

---

## Authentication

The API uses **Auth0** for authentication and JWT bearer tokens to protect API endpoints.

Sensitive configuration such as:

* API keys
* Client secrets
* Authentication credentials
* Passwords
* Database connection strings

must be stored in local configuration or environment variables and must **never be committed to source control**.

---

## Getting Started

### Prerequisites

* .NET SDK
* Auth0 application configured for authentication
* Credentials for the configured AI service

### Clone the Repository

```bash
git clone https://github.com/rajaniraju/AIHelpAssistant.git
cd AIHelpAssistant
```

### Configuration

Configure the required authentication and AI service settings using local development configuration or environment variables.

Do not commit secrets or credentials to the repository.

### Run the Application

```bash
dotnet restore
dotnet build
dotnet run
```

The application will start using the configured ASP.NET Core environment and port.

---

## Development Approach

The project is being developed incrementally with an emphasis on understanding the systems surrounding the application, not just the API layer.

Areas of focus include:

* API design
* Authentication and authorization
* AI service integration
* Document processing
* Data retrieval
* Semantic search
* RAG architecture
* Testing
* Debugging
* Application security
* AI-assisted development
* Continuous improvement

The project is intentionally evolving as new AI capabilities are explored and integrated.

---

## Future Development

Planned improvements include:

* Implement Azure OCR/document processing
* Build document verification workflows
* Introduce NLP processing
* Explore computer vision capabilities
* Implement document ingestion
* Generate embeddings
* Introduce a vector database
* Build the RAG retrieval pipeline
* Ground AI responses using retrieved application-specific information
* Expand automated test coverage
* Add structured logging and health monitoring
* Add CI/CD automation
* Evaluate retrieval quality and AI response accuracy

---

## Author

**Rajani Raju**

GitHub: https://github.com/rajaniraju

LinkedIn: https://www.linkedin.com/in/rajani-raju-17180433/
