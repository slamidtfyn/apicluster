kubectl apply -f .\apikube.yml

kubectl expose deployment api-deploy --type=NodePort --port 5010

