

from sentence_transformers import SentenceTransformer, util

model = SentenceTransformer(
    "sentence-transformers/all-MiniLM-L6-v2"
)

# Simulated document chunks
document_chunks = [
    "Artificial Intelligence helps computers understand human language.",
    "Machine learning allows computers to learn from data.",
    "Cats are domestic animals and make popular pets.",
    "Natural Language Processing helps machines understand text.",
    "Python is a popular programming language."
]

# User's question
# query = "How can computers understand human language?"
query = "Are Cats pets?"

# Generate document embeddings
chunk_embeddings = model.encode(document_chunks)

# Generate query embedding
query_embedding = model.encode(query)

# Compare query against all document chunks
similarity_scores = util.cos_sim(
    query_embedding,
    chunk_embeddings
)[0]

# Rank document chunks by similarity
ranked_results = similarity_scores.argsort(descending=True)
top_k = 3

ranked_results = similarity_scores.argsort(
    descending=True
)[:top_k]

print(f"\nTop {top_k} Results:\n")

for index in ranked_results:
    print("Score:", round(similarity_scores[index].item(), 4))
    print("Chunk:", document_chunks[index])
    print("-" * 50)

print("\nUser Question:", query)
print("\nMost relevant document chunks:\n")

for index in ranked_results:
    print("Score:", round(similarity_scores[index].item(), 4))
    print("Chunk:", document_chunks[index])
    print("-" * 60)
