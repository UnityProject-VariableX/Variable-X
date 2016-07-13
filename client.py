import socket

HOST, PORT = "127.0.0.1", 5000
#ctrl_cyc="1234567"
data = "left"
# data += str(ctrl_cyc)

    # Create a socket (SOCK_STREAM means a TCP socket)
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

try:
    # Connect to server and send data
    sock.connect((HOST, PORT))
    sock.sendall(data.encode('ascii'))
    data = sock.recv(1024)
    print (data)

finally:
    sock.close()
